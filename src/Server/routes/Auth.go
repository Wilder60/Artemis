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

//DBClient is a pointer to a mongo.Client struct for connection to the database
var DBClient *mongo.Client

//SetAuthRoutes sets the handler functions for the /Auth route.
//Parameters:
//		router -> pointer to a mux.Router
//Returns:
//		The router passed in as a parameter
func SetAuthRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/Auth", validateLogin).Methods("POST")
	router.HandleFunc("/Auth", createUser).Methods("PUT")
	router.HandleFunc("/Auth", updateUser).Methods("PATCH")
	router.HandleFunc("/Auth", deleteUser).Methods("DELETE")
	return router
}

//validateLogin is the function that handles all the POST requests for the /Auth route.
//Will query the database to see if the email exists and use bcrypt to compare the two passwords.
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		if a succesful login will return 200 and a Token
//		if not then 404, or 500
func validateLogin(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AccountsCollection := DBClient.Database("db").Collection("Accounts")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	LoginRequest, err := parseAuthRequest(Request)
	if err != nil {
		fmt.Fprintf(os.Stdout, "POST\t\\Auth\t500\n")
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	DBAccount := account.Account{}
	SearchErr := AccountsCollection.FindOne(ctx, bson.M{"email": LoginRequest.Email}).Decode(&DBAccount)
	if SearchErr != nil {
		fmt.Fprintf(os.Stdout, "POST\t\\Auth\t500\n")
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	ValidHash := bcrypt.CompareHashAndPassword([]byte(DBAccount.Password), []byte(LoginRequest.Password))
	if ValidHash != nil {
		fmt.Fprintf(os.Stdout, "POST\t\\Auth\t404\n")
		Writer.WriteHeader(http.StatusBadRequest)
		return
	}

	JWTToken, err := jwt.CreateToken(DBAccount)
	if err != nil {
		fmt.Fprintf(os.Stdout, "POST\t\\Auth\t500\n")
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	DBAccount.Password = ""
	EncodeAccount, err := json.Marshal(DBAccount)
	if err != nil {
		fmt.Fprintf(os.Stdout, "POST\t\\Auth\t500\n")
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	fmt.Fprintf(os.Stdout, "POST\t\\Auth\t200\n")
	Writer.Header().Set("MasterToken", JWTToken)
	Writer.WriteHeader(http.StatusAccepted)
	Writer.Write(EncodeAccount)
	return
}

//createUser is the function that handles all the GET requests for the /Auth route.
//Will query the database to see if an account already exists and returns if it does,
//else it will hash the password and store the struct in the database
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		202 Accepted if the account could be created
//		404 if an account already exists, 500 if an error occured
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
	NewAccount.ID = id.String()
	NewAccount.PageStyle = "Modern"

	_, Inserterr := AccConnection.InsertOne(ctx, NewAccount)
	if Inserterr != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	err = keyhook.CreateKeyHookAccount(NewAccount.ID)
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

//deleteUser is the function that handles all the DELETE requests for the /Auth route.
//Will query the database for an account with a matching id and remove it from the database
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		202 Accepted if the account could be created
//		404 if an account already exists, 500 if an error occured
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
	_, err = AccountsCollection.DeleteOne(ctx, bson.M{"id": DeleteRequest.ID})
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error parsing data"))
		return
	}
	keyhook.DeleteKeyHookAccount(DeleteRequest.ID)
	Writer.WriteHeader(http.StatusOK)
	return

}

//parseAuthRequest parses the http.Request
//Parameters:
//		Request -> the request that was sent by the user contain the account in the body
//Returns:
//		An instance of account.Account and nil if not errors happen
//		Else an empty account.Account and the error
func parseAuthRequest(Request *http.Request) (account.Account, error) {
	NewAccount := account.Account{}
	err := json.NewDecoder(Request.Body).Decode(&NewAccount)
	if err != nil {
		return account.Account{}, err
	}
	return NewAccount, nil
}
