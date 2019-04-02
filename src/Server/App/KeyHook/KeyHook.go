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
	Email string            `json:"email"`
	Keys  map[string]string `json:"keys"`
}

//AddNewKey Adds a new key to the user document
func AddNewKey(email, WebsiteName string) error {
	//Opening Up the Database connection and context
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	Account := keyHookAccount{}
	keysCollection.FindOne(ctx, bson.M{"email": email}).Decode(&Account)
	if Account.Keys == nil {
		Account.Keys = make(map[string]string)
	}

	_, found := Account.Keys[WebsiteName]
	if found {
		return errors.New("website already has a password")
	}
	Account.Keys[WebsiteName] = generateNewPassword()

	keysCollection.UpdateOne(
		ctx,
		bson.M{"email": email},
		bson.M{"$set": bson.M{"keys": Account.Keys}},
	)

	return nil
}

//GetAllkeys Gets all the keys for a single user
func GetAllkeys(email string) []byte {
	fmt.Fprintf(os.Stdout, email)
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	UserAccount := keyHookAccount{}
	keysCollection.FindOne(ctx, bson.M{"email": email}).Decode(&UserAccount)

	FlattenMap, err := json.Marshal(UserAccount.Keys)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
	}
	return FlattenMap
}

//ModifyExistingKey Will change a password for website
func ModifyExistingKey(email, WebsiteName string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := keyHookAccount{}
	DecodeErr := keysCollection.FindOne(ctx, bson.M{"email": email}).Decode(&UserAccount)
	if DecodeErr != nil {
		return DecodeErr
	}
	_, ok := UserAccount.Keys[WebsiteName]
	if ok != true {
		return errors.New("No Website Exists")
	}
	UserAccount.Keys[WebsiteName] = generateNewPassword()
	_, err := keysCollection.UpdateOne(ctx, bson.M{"email": email}, UserAccount)
	if err != nil {
		return err
	}
	return nil
}

//RemoveKeys Removes one or more keys from a user document
func RemoveKeys(email string, Websites []string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := keyHookAccount{}
	keysCollection.FindOne(ctx, bson.M{"email": email}).Decode(&UserAccount)

	for _, Website := range Websites {
		delete(UserAccount.Keys, Website)
	}

	keysCollection.UpdateOne(
		ctx,
		bson.M{"email": email},
		bson.M{"$set": bson.M{"keys": UserAccount.Keys}},
	)

	return nil
}

func generateNewPassword() string {
	const KeyLexicon = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?@#$%^&*-_+=/"
	NewKey := make([]byte, 32)
	for i := range NewKey {
		NewKey[i] = KeyLexicon[rand.Intn(len(KeyLexicon))]
	}
	return string(NewKey)
}

//CreateKeyHookAccount Creates a new Document for the user
func CreateKeyHookAccount(Newemail string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	NewAccount := keyHookAccount{}
	NewAccount.Email = Newemail
	_, err := keysCollection.InsertOne(ctx, NewAccount)
	if err != nil {
		return err
	}

	return nil
}

//DeleteKeyHookAccount Removes an account with the associated email name
func DeleteKeyHookAccount(emailToDelete string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	_, DeleteErr := keysCollection.DeleteOne(ctx, bson.M{"email": emailToDelete})
	if DeleteErr != nil {
		return DeleteErr
	}
	return nil
}
