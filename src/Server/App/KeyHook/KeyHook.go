package KeyHook

import (
	"context"
	"encoding/json"
	"errors"
	"math/rand"
	"time"

	"github.com/mongodb/mongo-go-driver/bson"
	"github.com/mongodb/mongo-go-driver/mongo"
)

type KeyHookAccount struct {
	Email string            `json:"Email"`
	Keys  map[string]string `json:"Keys"`
}

var DBClient *mongo.Client

func AddNewKey(Email, WebsiteName string) error {
	KeysCollection := DBClient.Database("db").Collection("Keys")
	Account := KeyHookAccount{}

	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	KeysCollection.FindOne(ctx, bson.M{"Email": Email}).Decode(Account)

	_, ok := Account.Keys[WebsiteName]
	if ok == true {
		return errors.New("Website already has password!")
	}
	var NewPassword string = generateNewPassword()
	Account.Keys[WebsiteName] = NewPassword

	_, err := KeysCollection.UpdateOne(ctx, bson.M{"Email": Account.Email}, Account)
	if err != nil {
		return err
	}

	return nil
}

func GetAllKeys(Email string) []byte {
	KeysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	UserAccount := KeyHookAccount{}
	KeysCollection.FindOne(ctx, bson.M{"Email": Email}).Decode(&UserAccount)

	FlattenMap, err := json.Marshal(UserAccount.Keys)
	if err != nil {
		panic(err)
	}
	return FlattenMap
}

func ModifyExistingKey(Email, WebsiteName string) error {
	KeysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := KeyHookAccount{}
	DecodeErr := KeysCollection.FindOne(ctx, bson.M{"Email": Email}).Decode(&UserAccount)
	if DecodeErr != nil {
		return DecodeErr
	}
	_, ok := UserAccount.Keys[WebsiteName]
	if ok != true {
		return errors.New("No Website Exists")
	}
	UserAccount.Keys[WebsiteName] = generateNewPassword()
	_, err := KeysCollection.UpdateOne(ctx, bson.M{"Email": Email}, UserAccount)
	if err != nil {
		return err
	}
	return nil
}

func DeleteKeyFromAccount(Email, Website string) error {
	KeysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UserAccount := KeyHookAccount{}
	DecodeErr := KeysCollection.FindOne(ctx, bson.M{"Email": Email}).Decode(&UserAccount)
	if DecodeErr != nil {
		return DecodeErr
	}
	delete(UserAccount.Keys, Website)
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

func CreateNewAccount(NewEmail string) error {
	KeysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	NewAccount := KeyHookAccount{}
	NewAccount.Email = NewEmail
	_, err := KeysCollection.InsertOne(ctx, NewAccount)
	if err != nil {
		return err
	}
	return nil
}

func DeleteKeyHookAccount(EmailToDelete string) error {
	KeysCollection := DBClient.Database("db").Collection("Keys")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	_, DeleteErr := KeysCollection.DeleteOne(ctx, bson.M{"Email": EmailToDelete})
	if DeleteErr != nil {
		return DeleteErr
	}
	return nil
}
