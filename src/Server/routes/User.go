package routes

import (
	calender "Artemis/App/Calender"
	jwt "Artemis/Security/Authentication/JWT"
	"context"
	"encoding/json"
	"fmt"
	"net/http"
	"os"
	"time"

	"github.com/gorilla/mux"
	"github.com/mongodb/mongo-go-driver/bson"
	"github.com/mongodb/mongo-go-driver/mongo"
)

//UDBClient is a pointer to a mongodb client object
var UDBClient *mongo.Client

//SetUserRoutes sets the handler functions for the /User route.
//Only Get and Detele are implented
//Parameters:
//		router -> pointer to a mux.Router
//Returns:
//		The router passed in as a parameter
func SetUserRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/User", getAllActiveAlarms).Methods("GET")
	router.HandleFunc("/User", deletePastAlarm).Methods("DELETE")
	return router
}

//getAllActiveAlarms is the function to handle GET requests.
//Authenticates the user then parses the URL for there ID and
//quieries the database for all timer for them that have went off.
//Parameters:
//		Writer -> An http.ResponseWriter to return the information
//		Request -> The http Request from the user contain the ID in the url
//Returns:
//		If everything was successful and array of eventinfos and 200
//		If errors ocurred: 401, 400, or 500
func getAllActiveAlarms(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		fmt.Fprintf(os.Stdout, "GET\t\\User\t401\n")
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte(err.Error()))
		return
	}

	CalenderCollection := DBClient.Database("db").Collection("Calender")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	UserID, ok := Request.URL.Query()["id"]
	if !ok {
		fmt.Fprintf(os.Stdout, "Get\t\\User\t400\n")
		Writer.WriteHeader(http.StatusBadRequest)
		Writer.Write([]byte("Invalid id"))
		return
	}
	cursor, err := CalenderCollection.Find(ctx,
		bson.M{"owner": UserID[0], "wentoff": true})

	NewAlerts := make([]calender.EventInfo, 0)
	Event := calender.EventInfo{}
	for cursor.Next(ctx) {
		cursor.Decode(&Event)
		fmt.Println(Event)
		NewAlerts = append(NewAlerts, Event)
	}

	Eventsjson, err := json.Marshal(NewAlerts)
	if err != nil {
		fmt.Fprintf(os.Stdout, "GET\t\\User\t500\n")
		Writer.WriteHeader(http.StatusBadRequest)
		return
	}

	fmt.Fprintf(os.Stdout, "Get\t\\User\t200\n")
	Writer.WriteHeader(http.StatusOK)
	Writer.Write(Eventsjson)
	return
}

//deletePastAlarm is the function to handle DELETE requests.
//Authenticates the user and parses the body of the request for
//the IDs of the Alarms to remove
//Parameters:
//		Writer -> An http.ResponseWriter to return the information
//		Request -> The http Request from the user contain the IDs of the Alarms in the body
//Returns:
//		If everything was successful 200
//		If errors ocurred: 401, or 500
func deletePastAlarm(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	err := jwt.ValidateToken(Request.Header["Authorization"][0])
	if err != nil {
		fmt.Fprintf(os.Stdout, "GET\t\\User\t401\n")
		Writer.WriteHeader(http.StatusUnauthorized)
		Writer.Write([]byte(err.Error()))
		return
	}

	CalenderCollection := UDBClient.Database("db").Collection("Calender")
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	var EventsToDelete []string
	ParseErr := json.NewDecoder(Request.Body).Decode(&EventsToDelete)
	if ParseErr != nil {
		fmt.Fprintf(os.Stdout, "DELETE\t\\User\t500\n")
		Writer.WriteHeader(http.StatusInternalServerError)
		return
	}

	for _, Event := range EventsToDelete {
		CalenderCollection.DeleteOne(ctx, bson.M{"id": Event})
	}

	fmt.Fprintf(os.Stdout, "DELETE\t\\User\t200\n")
	Writer.WriteHeader(http.StatusOK)
	return
}
