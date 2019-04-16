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
	PUT		-> Update one of the Keys (KeyName or KeyPass)
	DELETE 	-> Remove a Key from a user list
*/
func SetKeyHookRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/KeyHook", addKey).Methods("POST")
	router.HandleFunc("/KeyHook", getKeys).Methods("GET")
	router.HandleFunc("/KeyHook", modifyKey).Methods("PUT")
	router.HandleFunc("/KeyHook", removeKey).Methods("DELETE")
	return router
}

//addKeys the HandleFunc for the POST request of the Keyhook Route
//Adds a new Website name and generates a new password for it
//Will make a call App/KeyHook file
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user containing the userID
//			and the website to parse
//Returns:
//		http status 401 if there is no or an invalid token is present
//		http status 500 if an error happens during the parsing or inserting
//		http status 200 if the key was successfully inserted
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

//getKeys The Handlefunc for the GET request of the KeyHook route
//That will return all keys for a specifc user
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user containing the userID
//				in the URL
//Returns:
//		http status 401 if there is no or invalid token
//		http status 400 if the user id is not provided in the URL
//		http status 200 and a json containing all of the passwords and keys
func getKeys(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	UserID, ok := Request.URL.Query()["id"]
	if !ok {
		Writer.WriteHeader(http.StatusBadRequest)
		Writer.Write([]byte("Invalid id"))
		return
	}
	Keys := keyhook.GetAllkeys(UserID[0])
	fmt.Fprintf(os.Stdout, "GET\t\\KeyHook\t200\n")
	Writer.WriteHeader(http.StatusOK)
	Writer.Write(Keys)
	return
}

//modifyKey The Handlefunc for the PUT request of the KeyHook route
//This function will generate a new password for all of websites that are
//passed to it in the request
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user containing the userID
//			and an array containing all of the websites
//Returns:
//		http status 401 if there is no or invalid token
//		http status 500 if an error happens during the modiying
//		http status 200
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

	err = keyhook.ModifyExistingKey(RequestLogin.ID, RequestLogin.WebsiteArray)
	if err != nil {
		Writer.WriteHeader(http.StatusNotFound)
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//removeKeys The Handlefunc for the DELETE request of the KeyHook route
//This will delete all the keys and passwords for the given Website Names
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user containing the
//Returns:
//		http status 401 if there is no or invalid token
//		http status 500 if there is an error in the deleting
//		http status 200
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

//getKeys The Handlefunc for the GET request of the KeyHook route
//That will return all keys for a specifc user
//Parameters:
//		Request -> the http request containing the information to be
//			decoded into a keyHookRequest struct
//Returns:
//		if error decoding an empty object and the error
//		else the decoded struct and nil
func parseKeyHookRequest(Request *http.Request) (keyHookRequest, error) {
	NewRequest := keyHookRequest{}
	err := json.NewDecoder(Request.Body).Decode(&NewRequest)
	if err != nil {
		return keyHookRequest{}, err
	}
	return NewRequest, nil
}
