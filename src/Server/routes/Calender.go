package Routes

import (
	"fmt"
	"net/http"
)

//POST   - Send a new Event to be added to the calender (passing the JSON info)
//GET    - Gets all of the events that the user has (passing userID)
//PUT    - Updates an already existing event
//DELETE - Removes an even

func CreateEvent(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
	Request.ParseForm()

	for key, value := range Request.Form {
		fmt.Printf("%s = %s\n", key, value)
	}

	//Get the body from the JSON
	/*Whats missing:
	Parsing the body into a JSON Object(or Map)*/
	//NewEvent := Event.NewCalenderAlarm(Request.GetBody)
	//Store the new event in the DataBase
}

func RemoveEvent(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()
}
