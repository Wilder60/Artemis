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
func HealthCheck(Writer http.ResponseWriter, Reader *http.Request) {
	fmt.Printf("GET\t/\t200")
	fmt.Fprintf(Writer, "The server is up and running")
	Writer.WriteHeader(http.StatusOK)
	return
}

//CreateDatabaseConnection Connects the database to the different files
func CreateDatabaseConnection() *mongo.Client {
	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()
	client, err := mongo.Connect(ctx, "mongodb://localhost:27017")
	if err != nil {
		panic(err)
	}
	return client
}

//main function that will boot the server
func main() {
	router := mux.NewRouter()
	DBConnection := CreateDatabaseConnection()
	routes.DBClient = DBConnection
	keyhook.DBClient = DBConnection
	calender.DBClient = DBConnection

	//Adding the Handlers for each route
	router.HandleFunc("/", HealthCheck).Methods("GET")
	routes.SetAuthRoutes(router)
	routes.SetKeyHookRoutes(router)
	routes.SetCalenderRoutes(router)

	calender.StartAlarms()
	defer calender.ShutDownAlarms()
	if err := http.ListenAndServe(":3000", router); err != nil {
		log.Fatal(err)
	}
}
