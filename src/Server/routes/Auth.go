package routes

import (
	keyhook "Artemis/App/KeyHook"
	"Artemis/App/UserAccount"
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
	"golang.org/x/crypto/bcrypt"
)

//POST   - To validate a login is good or not
//PUT    - To create a new user
//UPDATE - To update an account with new user info
//DELETE - To remove a user from the database (and cancel all there active alarms)

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

	LoginRequest := UserAccount.AccountLogin{}
	err := json.NewDecoder(Request.Body).Decode(&LoginRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	DBAccount := UserAccount.EmptyAccount()
	SearchErr := AccountsCollection.FindOne(ctx, bson.M{"email": LoginRequest.EMAIL}).Decode(&DBAccount)
	if SearchErr != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	ValidHash := bcrypt.CompareHashAndPassword([]byte(DBAccount.PASSWORD), []byte(LoginRequest.PASSWORD))
	if ValidHash != nil {
		Writer.WriteHeader(http.StatusBadRequest)
		return
	}

	JWTToken, err := JWT.CreateToken(DBAccount)
	fmt.Println(JWTToken)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	Writer.Header().Set("MasterToken", JWTToken)
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//--------------------------FOR THE SIGNUP ROUTE-----------------------------//
func createUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	NewAccount := UserAccount.EmptyAccount()
	err := json.NewDecoder(Request.Body).Decode(&NewAccount)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	AccConnection := DBClient.Database("db").Collection("Accounts")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	count, err := AccConnection.Count(ctx, bson.M{"email": NewAccount.EMAIL})
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	if count != 0 {
		Writer.WriteHeader(http.StatusBadRequest)
		return
	}
	HASHPASS, err := bcrypt.GenerateFromPassword([]byte(NewAccount.PASSWORD), bcrypt.DefaultCost)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	NewAccount.PASSWORD = string(HASHPASS)
	_, Inserterr := AccConnection.InsertOne(ctx, NewAccount)
	if Inserterr != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	err = keyhook.CreateKeyHookAccount(NewAccount.EMAIL)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

func updateUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := JWT.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte(err.Error()))
		return
	}

}

func deleteUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := JWT.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte(err.Error()))
		return
	}
	Request.ParseForm()
	fmt.Println(Request.FormValue("email"))
	Writer.WriteHeader(http.StatusOK)
	return
	//KeyHook.DeleteKeyHookAccount(Request.FormValue("email"))
}

/*

 */
