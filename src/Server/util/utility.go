package util

import (
	"fmt"
	"net/http"
	"os"
)

//Respond Takes all the requests
//Parameters:
//		Writer -> The http.ResponseWriter
//		Status -> The http.status of the request
//		Content -> A byte Array of the content
//Returns:
//		void
func Respond(Writer http.ResponseWriter, Status int, Content []byte) {
	Writer.WriteHeader(Status)
	if Content != nil {
		Writer.Write(Content)
	}
	return
}

//RequestStatus Prints how the request was returned
//Parameters:
//		Method ->
//		Route ->
//		Status ->
//Returns:
//		void
func RequestStatus(Method, Route, Status string) {
	fmt.Fprintf(os.Stdout, Method+"\t\\"+Route+"\t"+Status+"\n")
}
