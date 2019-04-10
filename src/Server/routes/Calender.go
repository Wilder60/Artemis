package routes

import (
	"Artemis/App/Calender"
	"Artemis/Security/Authentication/JWT"
	"encoding/json"
	"fmt"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

/*
	POST   -> Creates a new event(JSON Object)
	GET    -> Gets all of the events that the user has until a certaintime(passing email)
	PUT    -> Update an existing event
	DELETE -> Removes an event an closes the channel
*/

//SetCalenderRoutes sets the handler functions for the /Calender route.
//Parameters:
//		router -> pointer to a mux.Router
//Returns:
//		The router passed in as a parameter
func SetCalenderRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/Calender", createEvent).Methods("POST")
	router.HandleFunc("/Calender", getUpcomingEvents).Methods("GET")
	router.HandleFunc("/Calender", updateEvent).Methods("PUT")
	router.HandleFunc("/Calender", removeEvent).Methods("DELETE")
	return router
}

//createEvent is the function that handles all the POST requests for the /Calender route.
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		202 if the calender was accepted and stored
//		if errors occured 500, 400
func createEvent(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	//this the person making the request valid
	AuthErr := jwt.ValidateToken(Request.Header["Authorization"][0])
	if AuthErr != nil {
		fmt.Fprintf(os.Stderr, AuthErr.Error())
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid token"))
		return
	}

	//try to parse the body into the struct
	CreateRequest, err := parseCalenderRequest(Request)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Invalid data sent over"))
		return
	}

	//post it to the database and start the timer
	err = calender.InsertEvent(CreateRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error Parsing Data"))
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//validateLogin is the function that handles all the POST requests for the /Auth route.
//Will query the database to see if the email exists and use bcrypt to compare the two passwords.
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		if a succesful login will return 200 and a Token
//		if not then 404, or 500
func getUpcomingEvents(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AuthErr := jwt.ValidateToken(Request.Header["Authorization"][0])
	if AuthErr != nil {
		fmt.Fprintf(os.Stderr, AuthErr.Error())
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid token"))
		return
	}
	GetRequest, ParseErr := parseCalenderRequest(Request)
	if ParseErr != nil {
		fmt.Fprintf(os.Stderr, ParseErr.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error Parsing Data"))
		return
	}

	_, err := calender.GetEvents(GetRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Something went wrong"))
		return
	}

	Writer.WriteHeader(http.StatusAccepted)
	return
}

//validateLogin is the function that handles all the POST requests for the /Auth route.
//Will query the database to see if the email exists and use bcrypt to compare the two passwords.
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		if a succesful login will return 200 and a Token
//		if not then 404, or 500
func updateEvent(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AuthErr := jwt.ValidateToken(Request.Header["Authorization"][0])
	if AuthErr != nil {
		fmt.Fprintf(os.Stderr, AuthErr.Error())
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid token"))
		return
	}

	updateRequest, ParseErr := parseCalenderRequest(Request)
	if ParseErr != nil {
		fmt.Fprintf(os.Stderr, ParseErr.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error Parsing Data"))
		return
	}

	err := calender.EditEvent(updateRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Something went wrong"))
		return
	}

	Writer.WriteHeader(http.StatusAccepted)
	return
}

//validateLogin is the function that handles all the POST requests for the /Auth route.
//Will query the database to see if the email exists and use bcrypt to compare the two passwords.
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		if a succesful login will return 200 and a Token
//		if not then 404, or 500
func removeEvent(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	AuthErr := jwt.ValidateToken(Request.Header["Authorization"][0])
	if AuthErr != nil {
		fmt.Fprintf(os.Stderr, AuthErr.Error())
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte("Invalid token"))
		return
	}

	removeRequest, ParseErr := parseCalenderRequest(Request)
	if ParseErr != nil {
		fmt.Fprintf(os.Stderr, ParseErr.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Error Parsing Data"))
		return
	}

	err := calender.RemoveEvent(removeRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Something went wrong"))
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//validateLogin is the function that handles all the POST requests for the /Auth route.
//Will query the database to see if the email exists and use bcrypt to compare the two passwords.
//Parameters:
//		Writer -> a http.ResponseWriter to return if the user is valid or not
//		Request -> the request that was sent by the user
//Returns:
//		if a succesful login will return 200 and a Token
//		if not then 404, or 500
func parseCalenderRequest(Request *http.Request) (calender.EventInfo, error) {
	NewEvent := calender.EventInfo{}
	err := json.NewDecoder(Request.Body).Decode(&NewEvent)
	if err != nil {
		return calender.EventInfo{}, err
	}
	return NewEvent, nil
}
