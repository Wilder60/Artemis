package main

import (
	"Artemis/App/Calender"
	"Artemis/App/KeyHook"
	"Artemis/routes"
	"context"
	"fmt"
	"log"
	"net/http"
	"time"

	"github.com/gorilla/mux"
	"github.com/mongodb/mongo-go-driver/mongo"
)

//HealthCheck function used just to check if the server is running
//This will take a GET request
//Parameters:
//		Writer -> The response writer for the http.ResponseWriter
//		Reader -> The http request from the client
//Returns:
//		The Text "The server is up and running" and a http Status 200
func HealthCheck(Writer http.ResponseWriter, Reader *http.Request) {
	fmt.Printf("GET\t/\t200")
	fmt.Fprintf(Writer, "The server is up and running")
	Writer.WriteHeader(http.StatusOK)
	return
}

//CreateDatabaseConnection Creates the connection to the database client
//Parameters:
//		none
//Returns:
//		A *mongo.Client connection
func CreateDatabaseConnection() *mongo.Client {
	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()
	client, err := mongo.Connect(ctx, "mongodb://localhost:27017")
	if err != nil {
		panic(err)
	}
	return client
}

//The main function of the server
//Will initialize all the database collections of the routes
//and set the Handler functions for each route
//Parameters:
//		none
//Returns:
//		none
func main() {
	router := mux.NewRouter()
	DBConnection := CreateDatabaseConnection()
	routes.DBClient = DBConnection
	keyhook.DBClient = DBConnection
	calender.DBClient = DBConnection
	routes.UDBClient = DBConnection

	//Adding the Handlers for each route
	router.HandleFunc("/", HealthCheck).Methods("GET")
	routes.SetAuthRoutes(router)
	routes.SetKeyHookRoutes(router)
	routes.SetCalenderRoutes(router)
	routes.SetUserRoutes(router)

	calender.StartUpCalender()
	defer calender.ShutDownCalender()
	if err := http.ListenAndServe(":3000", router); err != nil {
		log.Fatal(err)
	}
}
