package calender

import (
	"context"
	"fmt"
	"time"

	"github.com/mongodb/mongo-go-driver/mongo"
	"github.com/segmentio/ksuid"
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

//this array will hold all the pipes that will send the shutdown signal
var closeMap map[string]chan string
var updateMap map[string]chan EventInfo

//InsertEvent Inserting an event into the database for storage
func InsertEvent(NewEvent EventInfo) error {
	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	_, err := calenderCollection.InsertOne(ctx, NewEvent)
	if err != nil {
		return err
	}

	Newid := ksuid.New()
	NewEvent.EventID = Newid.String()

	closeMap[NewEvent.EventID] = make(chan string, 1)
	updateMap[NewEvent.EventID] = make(chan EventInfo, 1)
	go startCountDown(NewEvent, closeMap["meme"], updateMap["meme"])

	return nil
}

//startCountDown Function that will count down until the Alarm is to go off
func startCountDown(EventCountDown EventInfo, QuitChannel chan string, updateChannel chan EventInfo) {

	for int64(EventCountDown.AlarmTime-EventCountDown.AlarmOffset) > time.Now().Unix() {
		select {
		case <-QuitChannel:
			return
		case <-updateChannel:
			EventCountDown = <-updateChannel
		default:
			time.Sleep(1 * time.Second)
		}
	}
	fmt.Println(EventCountDown.EventName + " Alarm is going off!")
	delete(closeMap, "meme")
	delete(updateMap, "meme")
	close(QuitChannel)
	close(updateChannel)
	//send the info to the users route
	//delete from the database
	return
}

//StartAlarms starts all of the alarms that are in the server
func StartAlarms() {
	if closeMap == nil {
		closeMap = make(map[string](chan string))
	}
	if updateMap == nil {
		updateMap = make(map[string](chan EventInfo))
	}
	calenderCollection = DBClient.Database("db").Collection("Calender")
	//query database for all of the alarms
	//and restart them
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
