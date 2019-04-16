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

//The struct for the keyHook
type keyHookAccount struct {
	ID   string            `json:"email"`
	Keys map[string]string `json:"keys"`
}

//AddNewKey Adds a new key to the users account if the website doesnt have a key
//Will error if the website already has a password
//Parameters:
//		AccountID -> The ID of the user to add a new key too
//		WebstiteName -> The website to generate a new password for
//Returns:
//		error if the website already has a password
//		else returns nil
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

//GetAllkeys Gets all the keys for a single user and flattens the map
//Will error if Marshalling fails
//Parameters:
//		AccountID -> The userID to return the keys for
//Returns:
//		nil and error if Marshalling fails
//		else the FlattenMap and nil
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

//ModifyExistingKey Will change the passwords for all Website names in Websites Array
//Will error if the FindOne and UpdateOne fails
//Parameters:
//		AccountID -> The userID who makes the request
//		Websites -> The slice containing all the website names to be updated
//Returns:
//		error if FindOne or UpdateOne fails, else nil
func ModifyExistingKey(AccountID string, Websites []string) error {
	keysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := keyHookAccount{}
	DecodeErr := keysCollection.FindOne(ctx, bson.M{"id": AccountID}).Decode(&UserAccount)
	if DecodeErr != nil {
		return DecodeErr
	}

	for _, Website := range Websites {
		_, ok := UserAccount.Keys[Website]
		if ok != true {
			return errors.New(Website + " Does not exist")
		}
		NewPass := generateNewPassword()
		UserAccount.Keys[Website] = NewPass
	}

	_, err := keysCollection.UpdateOne(ctx,
		bson.D{
			bson.E{Key: "id", Value: AccountID}},
		bson.D{
			bson.E{Key: "$set", Value: bson.D{
				bson.E{Key: "keys", Value: UserAccount.Keys},
			}}},
	)

	if err != nil {
		return err
	}
	return nil
}

//RemoveKeys Removes all the websites in the Websites slice
//Parameters:
//		AccountID -> the userID who makes the call
//		Websites -> a slice containing all the website names to be removed
//Returns:
//		err if the FindOne or UpdateOne fails, else nil
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

//generateNewPassword Will create a new random string for the password
//Parameters:
//		none
//Returns:
//		a string of the new password
func generateNewPassword() string {
	rand.Seed(time.Now().UTC().UnixNano())
	const KeyLexicon = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?@#$%^&*-_+=/"
	NewKey := make([]byte, 32)
	for i := range NewKey {
		NewKey[i] = KeyLexicon[rand.Intn(len(KeyLexicon))]
	}
	return string(NewKey)
}

//CreateKeyHookAccount Creates a new KeyHookAccount and stores in the Keys Collections
//Parameters:
//		AccountID -> the userID of person creating the account
//Returns:
//		err if the insert fails, else nil
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

//DeleteKeyHookAccount Removes an account with the associated AccountID
//Parameters:
//		AccountID -> the ID of the account being deleted
//Returns:
//		nil if the delete was successfull, else and error
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
