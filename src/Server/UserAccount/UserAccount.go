package UserAccount

import "net/http"

type AccountLogin struct {
	EMAIL    string `json:"EMAIL" form:"EMAIL"`
	PASSWORD string `json:"PASSWORD" form:"PASSWORD"`
}

type Account struct {
	EMAIL     string `json:"EMAIL" form:"EMAIL"`
	PASSWORD  string `json:"PASSWORD" form:"PASSWORD"`
	FIRSTNAME string `json:"FIRSTNAME" form:"FIRSTNAME"`
	LASTNAME  string `json:"LASTNAME" form:"LASTNAME"`
}

//The request should contain the everything derived
//in the struct
func NewAccount(Request *http.Request) Account {
	NewAccount := Account{}
	NewAccount.EMAIL = Request.FormValue("EMAIL")
	NewAccount.PASSWORD = Request.FormValue("PASSWORD")
	NewAccount.FIRSTNAME = Request.FormValue("FIRSTNAME")
	NewAccount.LASTNAME = Request.FormValue("LASTNAME")
	return NewAccount
}

func EmptyAccount() Account {
	return Account{}
}
