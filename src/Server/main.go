package main

import (
	"ArtemisServer/Routes"
	"context"
	"fmt"
	"log"
	"net/http"
	"time"

	"github.com/gorilla/mux"
	"github.com/mongodb/mongo-go-driver/mongo"
)

//function used just to check if the server is running
func HealthCheck(a_Writer http.ResponseWriter, a_Reader *http.Request) {
	fmt.Fprintf(a_Writer, "The server is up and running")
}

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
	Routes.DBClient = DBConnection

	//Adding the Handlers for each route
	router.HandleFunc("/", HealthCheck).Methods("GET")
	Routes.SetAuthRoutes(router)

	if err := http.ListenAndServe(":3000", router); err != nil {
		log.Fatal(err)
	}
}
