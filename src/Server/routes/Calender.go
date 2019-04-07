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

//SetCalenderRoutes Sets the routes for the calender
func SetCalenderRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/Calender", createEvent).Methods("POST")
	router.HandleFunc("/Calender", getUpcomingEvents).Methods("GET")
	router.HandleFunc("/Calender", updateEvent).Methods("PUT")
	router.HandleFunc("/Calender", removeEvent).Methods("DELETE")
	return router
}

//createEvent
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

//removeEvent
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

	err := calender.RemoveRunningEvent(removeRequest)
	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
		Writer.WriteHeader(http.StatusInternalServerError)
		Writer.Write([]byte("Something went wrong"))
		return
	}
	Writer.WriteHeader(http.StatusAccepted)
	return
}

//------------------------------UTILITY FUNCTIONS----------------------------//
func parseCalenderRequest(Request *http.Request) (calender.EventInfo, error) {
	NewEvent := calender.EventInfo{}
	err := json.NewDecoder(Request.Body).Decode(&NewEvent)
	if err != nil {
		return calender.EventInfo{}, err
	}
	return NewEvent, nil
}
