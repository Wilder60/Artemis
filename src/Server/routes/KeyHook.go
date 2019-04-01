package Routes

import (
	"Artemis/App/KeyHook"
	"Artemis/Authentication/JWT"
	"fmt"
	"net/http"

	"github.com/gorilla/mux"
)

/*
	POST	-> Add a key for a user
	GET		-> Get all the keys for a single user
	PATCH	-> Update one of the Keys (KeyName or KeyPass)
	DELETE 	-> Remove a Key from a user list

*/
func SetKeyHookRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/KeyHook", addKey).Methods("POST")
	router.HandleFunc("/KeyHook", getKeys).Methods("GET")
	router.HandleFunc("/KeyHook", modifyKey).Methods("PATCH")
	router.HandleFunc("/KeyHook", removeKey).Methods("DELETE")
	return router
}

//Adds a key to the appropiate account
func addKey(Writer http.ResponseWriter, Request *http.Request) {
	Request.ParseForm()
	defer Request.Body.Close()

	err := JWT.ValidateToken(Request)
	if err != nil {
		fmt.Println("POST\t\\Auth\t200")
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	err = KeyHook.AddNewKey(Request.FormValue("Email"), Request.FormValue("Website"))
	if err != nil {
		fmt.Printf("POST\t\\Auth\t500")
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte(err.Error()))
		return
	}

	fmt.Printf("POST\t\\Auth\t204")
	Writer.WriteHeader(http.StatusAccepted)
	return

}

func getKeys(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	Request.ParseForm()
	err := JWT.ValidateToken(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}
	Keys := KeyHook.GetAllKeys(Request.FormValue("Email"))
	Writer.WriteHeader(http.StatusOK)
	Writer.Write(Keys)

}

func modifyKey(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := JWT.ValidateToken(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}
	Request.ParseForm()
	err = KeyHook.ModifyExistingKey(Request.FormValue("Email"), Request.FormValue("Website"))
	if err != nil {
		Writer.WriteHeader(http.StatusNotFound)
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

func removeKey(Writer http.ResponseWriter, Request *http.Request) {
	err := JWT.ValidateToken(Request)
	if err != nil {
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid Token"))
		return
	}

	Writer.WriteHeader(http.StatusAccepted)
	return
}
