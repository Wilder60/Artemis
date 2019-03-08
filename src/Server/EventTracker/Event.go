package EventTracker

import (
	"strconv"
	"time"
)

//The basic struct the makes an event that will alarm the user
//this will be expaned more to add more verbose features
type m_EventAlarm struct {
	EventOwner    string    //The id of the user that owns the alarm
	EventName     string    //The name of the event
	EventLocation string    //The location of the event
	EventType     string    //The type of the event (alarm, calender, etc)
	StartEndTime  string    //The start time to the end time (can be all day)
	AlarmTime     time.Time //The start of the alarm
	AlarmOffset   time.Time //When the alarm should send a notification to the user
}

//The constructor for creating a new Alarm event
func NewTimeAlarm(a_AlarmData map[string]interface{}) (m_EventAlarm, error) {
	Alarm := m_EventAlarm{}
	Alarm.EventOwner = ""
	Alarm.EventName = ""
	Alarm.EventLocation = ""
	Alarm.EventType = a_AlarmData["EventType"].(string)
	Time, err := StringToTime(a_AlarmData["ALARMTIME"].(string))
	if err != nil {
		return m_EventAlarm{}, err
	}

	Alarm.AlarmTime = Time
	return Alarm, nil
}

//The constructor for the creating a new Calender Alarm event
//This is different from the Alarm constructor because more information
//will be passed in the JSON
func NewCalenderAlarm(a_CalenderData map[string]interface{}) (m_EventAlarm, error) {
	Alarm := m_EventAlarm{}

	return Alarm, nil
}

//Helper function to convert a string of time in ms to a time struct
//that can be used to count down in a goroutine
func StringToTime(a_TimeString string) (time.Time, error) {
	MsInt, err := strconv.ParseInt(a_TimeString, 10, 64)
	if err != nil {
		return time.Time{}, nil
	}
	return time.Unix(0, MsInt*int64(time.Millisecond)), nil
}
