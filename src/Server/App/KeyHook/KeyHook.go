package keyhook

import (
	"context"
	"encoding/json"
	"errors"
	"fmt"
	"math/rand"
	"os"
	"time"

	"github.com/mongodb/mongo-go-driver/bson"
	"github.com/mongodb/mongo-go-driver/mongo"
)

//DBClient The connection to the database assigned at runtime
var DBClient *mongo.Client

type keyHookAccount struct {
	ID   string            `json:"email"`
	Keys map[string]string `json:"keys"`
}

//AddNewKey Adds a new key to the user document
func AddNewKey(AccountID, WebsiteName string) error {
	//Opening Up the Database connection and context
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	Account := keyHookAccount{}
	keysCollection.FindOne(ctx, bson.M{"id": AccountID}).Decode(&Account)
	if Account.Keys == nil {
		Account.Keys = make(map[string]string)
	}

	_, found := Account.Keys[WebsiteName]
	if found {
		return errors.New("website already has a password")
	}
	Account.Keys[WebsiteName] = generateNewPassword()
	/*
		Epassword, EncryptErr := crypto.Encrypt(generateNewPassword())
		if EncryptErr != nil {
			return EncryptErr
		}
		Account.Keys[WebsiteName] = Epassword
	*/

	keysCollection.UpdateOne(
		ctx,
		bson.M{"id": AccountID},
		bson.M{"$set": bson.M{"keys": Account.Keys}},
	)

	return nil
}

//GetAllkeys Gets all the keys for a single user
func GetAllkeys(AccountID string) []byte {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	UserAccount := keyHookAccount{}
	keysCollection.FindOne(ctx, bson.M{"id": AccountID}).Decode(&UserAccount)

	/*
		for Website, password := range UserAccount.Keys {
				rawPass, err := crypto.Decrypt(password)
				if err != nil {
					fmt.Fprintf(os.Stderr, err.Error())
				} else {
					UserAccount.Keys[Website] = string(rawPass)
				}
		}
	*/

	FlattenMap, err := json.Marshal(UserAccount.Keys)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
	}
	return FlattenMap
}

//ModifyExistingKey Will change a password for website
func ModifyExistingKey(AccountID, WebsiteName string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := keyHookAccount{}
	DecodeErr := keysCollection.FindOne(ctx, bson.M{"id": AccountID}).Decode(&UserAccount)
	if DecodeErr != nil {
		return DecodeErr
	}
	_, ok := UserAccount.Keys[WebsiteName]
	if ok != true {
		return errors.New("No Website Exists")
	}
	UserAccount.Keys[WebsiteName] = generateNewPassword()
	_, err := keysCollection.UpdateOne(ctx, bson.M{"id": AccountID}, UserAccount)
	if err != nil {
		return err
	}
	return nil
}

//RemoveKeys Removes one or more keys from a user document
func RemoveKeys(AccountID string, Websites []string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := keyHookAccount{}
	keysCollection.FindOne(ctx, bson.M{"id": AccountID}).Decode(&UserAccount)

	for _, Website := range Websites {
		delete(UserAccount.Keys, Website)
	}

	keysCollection.UpdateOne(
		ctx,
		bson.M{"id": AccountID},
		bson.M{"$set": bson.M{"keys": UserAccount.Keys}},
	)

	return nil
}

func generateNewPassword() string {
	rand.Seed(time.Now().UTC().UnixNano())
	const KeyLexicon = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?@#$%^&*-_+=/"
	NewKey := make([]byte, 32)
	for i := range NewKey {
		NewKey[i] = KeyLexicon[rand.Intn(len(KeyLexicon))]
	}
	return string(NewKey)
}

//CreateKeyHookAccount Creates a new Document for the user
func CreateKeyHookAccount(AccountID string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	NewAccount := keyHookAccount{}
	NewAccount.ID = AccountID
	_, err := keysCollection.InsertOne(ctx, NewAccount)
	if err != nil {
		return err
	}

	return nil
}

//DeleteKeyHookAccount Removes an account with the associated email name
func DeleteKeyHookAccount(AccountID string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	_, DeleteErr := keysCollection.DeleteOne(ctx, bson.M{"id": AccountID})
	if DeleteErr != nil {
		return DeleteErr
	}
	return nil
}
