package Routes

import (
	"ArtemisServer/Authentication/JWT"
	"ArtemisServer/UserAccount"
	"context"
	"encoding/json"
	"net/http"
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

var DBClient *mongo.Client

func SetAuthRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/Auth", validateLogin).Methods("POST")
	router.HandleFunc("/Auth", createUser).Methods("PUT")
	router.HandleFunc("/Auth", updateUser).Methods("PATCH")
	router.HandleFunc("/Auth", deleteUser).Methods("DELETE")
	return router
}

//TODO ADD JWT Authenitcation
//-----------------------------For Login Route-------------------------------//
func validateLogin(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AccountsCollection := DBClient.Database("db").Collection("Accounts")

	LoginRequest := UserAccount.AccountLogin{}
	err := json.NewDecoder(Request.Body).Decode(&LoginRequest)
	if err != nil {
		panic(err)
	}

	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	DBAccount := UserAccount.EmptyAccount()
	SearchErr := AccountsCollection.FindOne(ctx, bson.M{"email": LoginRequest.EMAIL}).Decode(&DBAccount)
	if SearchErr != nil {
		panic(err)
	}

	ValidHash := bcrypt.CompareHashAndPassword([]byte(DBAccount.PASSWORD), []byte(LoginRequest.PASSWORD))
	if ValidHash != nil {
		Writer.WriteHeader(http.StatusBadRequest)
		return
	}

	JWTToken, err := JWT.CreateToken(DBAccount)
	if err != nil {
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	Writer.Header().Set("Token", JWTToken)
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//--------------------------FOR THE SIGNUP ROUTE-----------------------------//
func createUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()

	NewAccount := UserAccount.EmptyAccount()
	err := json.NewDecoder(Request.Body).Decode(&NewAccount)
	if err != nil {
		panic(err)
	}

	AccConnection := DBClient.Database("db").Collection("Accounts")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	count, err := AccConnection.Count(ctx, bson.M{"email": NewAccount.EMAIL})
	if err != nil {
		panic(err)
	}

	if count != 0 {
		Writer.WriteHeader(http.StatusNotFound)
		return
	}

	HASHPASS, err := bcrypt.GenerateFromPassword([]byte(NewAccount.PASSWORD), bcrypt.DefaultCost)
	if err != nil {
		panic(err)
	}

	NewAccount.PASSWORD = string(HASHPASS)
	_, Inserterr := AccConnection.InsertOne(ctx, NewAccount)
	if Inserterr != nil {
		panic(err)
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

func updateUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := JWT.ValidateToken(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusNotFound)
		return
	}

}

func deleteUser(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()

	err := JWT.ValidateToken(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusNotFound)
		return
	}

}
