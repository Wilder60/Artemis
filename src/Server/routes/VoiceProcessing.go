package routes

import (
	"net/http"
)

/*
//TODO
	1. Pull the JSON data that is sent over from the Client
	2. Pass the byte stream(or file) in the voice processing function and Get the return string
	3. Decide if you can do anything with the string
	4. if you can process the string do it and execute the command
	5. else get an error message
	6. convert the error message to audio and return that to the client
*/
func ParseRequest(Writer http.ResponseWriter, Request *http.Request) {
	defer Request.Body.Close()

}
