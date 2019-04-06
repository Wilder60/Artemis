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

//EventInfo Structure of the event data
type EventInfo struct {
	EventID       string `json:"eventid,omitempty"`
	EventOwner    string `json:"eventowner,omitempty"`    //The id of the user that owns the alarm
	EventName     string `json:"eventname,omitempty"`     //The name of the event
	EventLocation string `json:"eventlocation,omitempty"` //The location of the event
	EventLength   string `json:"eventlength,omitempty"`   //The start time to the end time (can be all day)
	AlarmTime     int    `json:"alarmtime,omitempty"`     //The start of the alarm
	AlarmOffset   int    `json:"alarmoffset,omitempty"`   //When the alarm should send a notification to the user
}

//DBClient connection to the mongodb database
var DBClient *mongo.Client
var calenderCollection *mongo.Collection

//map that holds the pipes for:
//	shutdown a goroutine
var closeMap map[string]chan string

//	to update the event
var updateMap map[string]chan EventInfo

//InsertEvent Inserting an event into the database for storage
func InsertEvent(NewEvent EventInfo) error {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	NewID := xid.New()
	NewEvent.EventID = NewID.String()

	_, err := calenderCollection.InsertOne(ctx, NewEvent)
	if err != nil {
		return err
	}

	closeMap[NewEvent.EventID] = make(chan string, 1)
	updateMap[NewEvent.EventID] = make(chan EventInfo, 1)
	go startCountDown(NewEvent, closeMap[NewEvent.EventID], updateMap[NewEvent.EventID])

	return nil
}

//GetEvents Gets all of the events upto one month in advance
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

	_, UpdateErr := calenderCollection.UpdateOne(
		ctx,
		bson.M{"eventid": UpdateEvent.EventID},
		UpdateEvent)

	if UpdateErr != nil {
		return UpdateErr
	}

	updateMap[UpdateEvent.EventID] <- UpdateEvent
	return nil
}

//RemoveRunningEvent Removes a event from a database, stops the goroutine, and closes the channels
func RemoveRunningEvent(RemoveEvent EventInfo) error {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	closeMap[RemoveEvent.EventID] <- "quit"
	_, err := calenderCollection.DeleteOne(
		ctx,
		bson.M{"eventid": RemoveEvent.EventID})
	if err != nil {
		return err
	}

	close(closeMap[RemoveEvent.EventID])
	close(updateMap[RemoveEvent.EventID])
	return nil
}

//startCountDown Function that will count down until the Alarm is to go off
func startCountDown(EventCountDown EventInfo, quitChannel chan string, updateChannel chan EventInfo) {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	for int64(EventCountDown.AlarmTime-EventCountDown.AlarmOffset) > time.Now().Unix() {
		select {
		case <-quitChannel:
			return
		case <-updateChannel:
			EventCountDown = <-updateChannel
		default:
			time.Sleep(1 * time.Second)
		}
	}
	fmt.Println(EventCountDown.EventName + " Alarm is going off!")
	//send the info to the users route
	_, err := calenderCollection.DeleteOne(
		ctx,
		bson.M{"eventid": EventCountDown.EventID})

	if err != nil {
		fmt.Fprintf(os.Stderr, err.Error())
	}
	return
}

//StartAlarms starts all of the alarms that are in the server
func StartAlarms() {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	if closeMap == nil {
		closeMap = make(map[string](chan string))
	}
	if updateMap == nil {
		updateMap = make(map[string](chan EventInfo))
	}
	calenderCollection = DBClient.Database("db").Collection("Calender")

	var Documents []EventInfo
	cursor, _ := calenderCollection.Find(ctx, bson.M{})
	cursor.Decode(&Documents)

	for i := 0; i < len(Documents); i++ {
		closeMap[Documents[i].EventID] = make(chan string, 1)
		updateMap[Documents[i].EventID] = make(chan EventInfo, 1)
		go startCountDown(Documents[i], closeMap[Documents[i].EventID], updateMap[Documents[i].EventID])
	}

	return
}

//ShutDownAlarms this will run when the server closes
func ShutDownAlarms() {
	for _, QuitChannel := range closeMap {
		QuitChannel <- "quit"
		close(QuitChannel)
	}

	for _, updateChannel := range updateMap {
		close(updateChannel)
	}

	return
}
