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

//UDBClient stuff
var UDBClient *mongo.Client

//SetUserRoutes sets routes
func SetUserRoutes(router *mux.Router) *mux.Router {
	router.HandleFunc("/User", getAllActiveAlarms).Methods("GET")
	router.HandleFunc("/User", deletePastAlarm).Methods("DELETE")
	return router
}

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
		bson.M{"eventowner": UserID[0], "wentoff": true})

	NewAlerts := make([]calender.EventInfo, 0)
	Event := calender.EventInfo{}
	for cursor.Next(ctx) {
		cursor.Decode(&Event)
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
		CalenderCollection.DeleteOne(ctx, bson.M{"eventid": Event})
	}

	fmt.Fprintf(os.Stdout, "DELETE\t\\User\t200\n")
	Writer.WriteHeader(http.StatusOK)
	return
}
