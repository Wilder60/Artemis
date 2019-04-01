package main

import (
	"Artemis/App/KeyHook"
	"Artemis/Routes"
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
	fmt.Printf("GET\t/\t200")
	fmt.Fprintf(a_Writer, "The server is up and running")
	a_Writer.WriteHeader(http.StatusOK)
	return
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
	KeyHook.DBClient = DBConnection

	//Adding the Handlers for each route
	router.HandleFunc("/", HealthCheck).Methods("GET")
	Routes.SetAuthRoutes(router)
	Routes.SetKeyHookRoutes(router)

	if err := http.ListenAndServe(":3000", router); err != nil {
		log.Fatal(err)
	}
}
