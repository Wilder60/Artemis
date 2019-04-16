package calender

import (
	"context"
	"fmt"
	"os"
	"time"

	"github.com/mongodb/mongo-go-driver/bson"
	"github.com/mongodb/mongo-go-driver/mongo"
	"github.com/rs/xid"
)

//EventInfo Contains all the information that an event needs
type EventInfo struct {
	EventID       string `json:"eventid,omitempty"`       //The eventname of the id
	EventOwner    string `json:"eventowner,omitempty"`    //The id of the user that owns the alarm
	EventName     string `json:"eventname,omitempty"`     //The name of the event
	EventLocation string `json:"eventlocation,omitempty"` //The location of the event
	EventLength   string `json:"eventlength,omitempty"`   //The start time to the end time (can be all day)
	AlarmTime     int64  `json:"alarmtime,omitempty"`     //The start of the alarm
	AlarmOffset   int64  `json:"alarmoffset,omitempty"`   //When the alarm should send a notification to the user
	NotifyTime    int64  `json:"notifytime,omitempty"`    //When the time goes off
	WentOff       bool   `json:"wentoff,omitempty"`       //Will determine if the alarm has went off
}

//DBClient connection to the mongodb database
var DBClient *mongo.Client

//mongo.Collection is a pointer to the Calender Collection
var calenderCollection *mongo.Collection

//The channel for closing the running go routine
var closingChanel chan string

//InsertEvent Inserting a new EventInfo into the database
//Parameters:
//		NewEvent -> An EventInfo struct containing the event information
//Returns:
//		err if the insertion fails else nil
func InsertEvent(NewEvent EventInfo) error {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	NewID := xid.New()
	NewEvent.EventID = NewID.String()
	NewEvent.NotifyTime = NewEvent.AlarmTime - NewEvent.AlarmOffset
	NewEvent.WentOff = false
	_, err := calenderCollection.InsertOne(ctx, NewEvent)
	if err != nil {
		return err
	}

	return nil
}

//GetEvents Gets all the Events for a specific owner within one month
//Parameters:
//		GetRequest -> the EventInfo containing userID
//Returns:
//		nil and err if Find query fails else
//		an array containing all struct and nil
func GetEvents(GetRequest EventInfo) ([]EventInfo, error) {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	cancel()

	var allEvents []EventInfo
	cursor, err := calenderCollection.Find(
		ctx,
		bson.M{
			"eventowner": GetRequest.EventOwner,
			"$and":       bson.M{"alarmtime": bson.M{"$lte": time.Now().Unix() + 2628000}}})

	if err != nil {
		return nil, err
	}
	cursor.Decode(&allEvents)
	return allEvents, nil
}

//EditEvent Updates an event that is currently running
func EditEvent(UpdateEvent EventInfo) error {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	UpdateEvent.NotifyTime = UpdateEvent.AlarmTime - UpdateEvent.AlarmOffset
	UpdateEvent.WentOff = false

	_, UpdateErr := calenderCollection.UpdateOne(
		ctx,
		bson.M{"eventid": UpdateEvent.EventID},
		UpdateEvent)

	if UpdateErr != nil {
		return UpdateErr
	}

	return nil
}

//RemoveEvent Removes the event with the matching ID
//Parameters:
//		RemoveEvent -> The EventInfo struct containing the ID
//Returns:
//		nil if there is no error
//		else the error
func RemoveEvent(RemoveEvent EventInfo) error {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	_, err := calenderCollection.DeleteOne(
		ctx,
		bson.M{"eventid": RemoveEvent.EventID})

	if err != nil {
		return err
	}

	return nil
}

//StartUpCalender The start up function that makes a connection
//to the Calender Collection, and make a channel to quit the go routine
//and starts the go routine
//Parameters:
//		none
//Returns:
//		none
func StartUpCalender() {
	fmt.Fprintf(os.Stdout, "Starting Calender\n")
	calenderCollection = DBClient.Database("db").Collection("Calender")
	closingChanel = make(chan string)
	go checkAlarms(closingChanel)
}

//checkAlarms Will query the database for all documents that have
//there notifytime as being after or equal the time now
//Parameters:
//		QuitChannel -> the channel that will send the quit message
//Returns:
//		None
func checkAlarms(QuitChannel chan string) {
	for true {
		select {
		case <-QuitChannel:
			return
		default:
			calenderCollection.UpdateMany(
				context.Background(),
				bson.D{
					bson.E{Key: "notifytime", Value: bson.D{
						bson.E{Key: "$lt", Value: time.Now().Unix()},
					}},
				},
				bson.D{
					bson.E{Key: "$set", Value: bson.D{
						bson.E{Key: "wentoff", Value: true},
					}}},
			)
			time.Sleep(1)
		}
	}
	fmt.Fprintf(os.Stdout, "checker shutting down\n")
}

//ShutDownCalender stops the GoRoutine and closes the channel
//Parameters:
//		none
//Returns:
//		none
func ShutDownCalender() {
	closingChanel <- "quit"
	close(closingChanel)
	fmt.Fprintf(os.Stdout, "Calender Shut Down\n")
}
