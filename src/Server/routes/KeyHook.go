package routes

import (
	"Artemis/App/KeyHook"
	"Artemis/Security/Authentication/JWT"
	"encoding/json"
	"fmt"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

//TODO: Add Crypto to the keys

type keyHookRequest struct {
	ID           string   `form:"id"`
	Website      string   `form:"website,omitempty"`
	WebsiteArray []string `form:"websiteArray,omitempty"`
}

/*
SetKeyHookRoutes Setting the functions for the KeyHook routes
	POST	-> Add a key for a user
	GET		-> Get all the keys for a single user
	PUT	-> Update one of the Keys (KeyName or KeyPass)
	DELETE 	-> Remove a Key from a user list
*/
func SetKeyHookRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/KeyHook", addKey).Methods("POST")
	router.HandleFunc("/KeyHook", getKeys).Methods("GET")
	router.HandleFunc("/KeyHook", modifyKey).Methods("PUT")
	router.HandleFunc("/KeyHook", removeKey).Methods("DELETE")
	return router
}

//Adds a key to the appropiate account
func addKey(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		fmt.Fprintf(os.Stdout, "POST\t\\KeyHook\t"+string(http.StatusUnauthorized)+"\n")
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	addRequest := keyHookRequest{}
	err = json.NewDecoder(Request.Body).Decode(&addRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error()+"\n")
		fmt.Fprintf(os.Stdout, "POST\t\\KeyHook\t"+string(http.StatusInternalServerError)+"\n")
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte(err.Error()))
		return
	}

	err = keyhook.AddNewKey(addRequest.ID, addRequest.Website)
	if err != nil {
		fmt.Printf("POST\t\\Auth\t500\n")
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte(err.Error()))
		return
	}

	fmt.Printf("POST\t\\Auth\t202\n")
	Writer.WriteHeader(http.StatusAccepted)
	return

}

func getKeys(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	GetRequest, err := parseKeyHookRequest(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte(err.Error()))
	}

	Keys := keyhook.GetAllkeys(GetRequest.ID)
	//loop and decrypt the keys
	Writer.WriteHeader(http.StatusOK)
	Writer.Write(Keys)
	return
}

func modifyKey(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	RequestLogin, err := parseKeyHookRequest(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte(err.Error()))
		return
	}

	err = keyhook.ModifyExistingKey(RequestLogin.ID, RequestLogin.Website)
	if err != nil {
		Writer.WriteHeader(http.StatusNotFound)
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

func removeKey(Writer http.ResponseWriter, Request *http.Request) {
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	removeRequest, err := parseKeyHookRequest(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte(err.Error()))
		return
	}
	keyhook.RemoveKeys(removeRequest.ID, removeRequest.WebsiteArray)
	Writer.WriteHeader(http.StatusAccepted)
	return
}

func parseKeyHookRequest(Request *http.Request) (keyHookRequest, error) {
	NewRequest := keyHookRequest{}
	err := json.NewDecoder(Request.Body).Decode(&NewRequest)
	if err != nil {
		return keyHookRequest{}, err
	}
	return NewRequest, nil
}
