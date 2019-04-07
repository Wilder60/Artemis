package routes

import (
	"Artemis/App/Account"
	keyhook "Artemis/App/KeyHook"
	"Artemis/Security/Authentication/JWT"
	"context"
	"encoding/json"
	"fmt"
	"net/http"
	"os"
	"time"

	"github.com/gorilla/mux"
	"github.com/mongodb/mongo-go-driver/bson"
	"github.com/mongodb/mongo-go-driver/mongo"
	"github.com/rs/xid"
	"golang.org/x/crypto/bcrypt"
)

/*
	POST   -> To validate a login is good or not
	PUT    -> To create a new user
	UPDATE -> To update an account with new user info
	DELETE -> To remove a user from the database (and cancel all there active alarms)
*/

//DBClient connection to the the mongo connect that will be connected in main
var DBClient *mongo.Client

//SetAuthRoutes Setting the Routes for the router
func SetAuthRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/Auth", validateLogin).Methods("POST")
	router.HandleFunc("/Auth", createUser).Methods("PUT")
	router.HandleFunc("/Auth", updateUser).Methods("PATCH")
	router.HandleFunc("/Auth", deleteUser).Methods("DELETE")
	return router
}

//-----------------------------For Login Route-------------------------------//
func validateLogin(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AccountsCollection := DBClient.Database("db").Collection("Accounts")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	LoginRequest, err := parseAuthRequest(Request)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	DBAccount := account.Account{}
	SearchErr := AccountsCollection.FindOne(ctx, bson.M{"email": LoginRequest.Email}).Decode(&DBAccount)
	if SearchErr != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	ValidHash := bcrypt.CompareHashAndPassword([]byte(DBAccount.Password), []byte(LoginRequest.Password))
	if ValidHash != nil {
		Writer.WriteHeader(http.StatusBadRequest)
		return
	}

	JWTToken, err := jwt.CreateToken(DBAccount)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	DBAccount.Password = ""
	EncodeAccount, err := json.Marshal(DBAccount)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	Writer.Header().Set("MasterToken", JWTToken)
	Writer.WriteHeader(http.StatusAccepted)
	Writer.Write(EncodeAccount)
	return
}

//--------------------------FOR THE SIGNUP ROUTjE-----------------------------//
func createUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AccConnection := DBClient.Database("db").Collection("Accounts")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	NewAccount, err := parseAuthRequest(Request)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	count, err := AccConnection.Count(ctx, bson.M{"email": NewAccount.Email})
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	if count != 0 {
		Writer.WriteHeader(http.StatusBadRequest)
		Writer.Write([]byte("An account with that email already exists!"))
		return
	}

	HASHPASS, err := bcrypt.GenerateFromPassword([]byte(NewAccount.Password), bcrypt.DefaultCost)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	NewAccount.Password = string(HASHPASS)
	id := xid.NewWithTime(time.Now())
	NewAccount.Id = id.String()
	NewAccount.PageStyle = "Modern"

	_, Inserterr := AccConnection.InsertOne(ctx, NewAccount)
	if Inserterr != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	err = keyhook.CreateKeyHookAccount(NewAccount.Id)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//incoming data should look like
//id, email, firstname, lastname
func updateUser(Writer http.ResponseWriter, Request *http.Request) {
	//AccountCollection := DBClient.Database("db").Collection("Accounts")
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte(err.Error()))
		return
	}

}

func deleteUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte(err.Error()))
		return
	}

	AccountsCollection := DBClient.Database("db").Collection("Accounts")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	DeleteRequest, err := parseAuthRequest(Request)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error parsing data"))
		return
	}
	_, err = AccountsCollection.DeleteOne(ctx, bson.M{"id": DeleteRequest.Id})
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error parsing data"))
		return
	}
	keyhook.DeleteKeyHookAccount(DeleteRequest.Id)
	Writer.WriteHeader(http.StatusOK)
	return

}

func parseAuthRequest(Request *http.Request) (account.Account, error) {
	NewAccount := account.Account{}
	err := json.NewDecoder(Request.Body).Decode(&NewAccount)
	if err != nil {
		return account.Account{}, err
	}
	return NewAccount, nil
}
