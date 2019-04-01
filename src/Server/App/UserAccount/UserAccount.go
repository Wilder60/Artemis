package UserAccount

import "net/http"

type AccountLogin struct {
	EMAIL    string `json:"email" form:"password"`
	PASSWORD string `json:"password" form:"password"`
}

type Account struct {
	EMAIL     string `json:"email" form:"email"`
	PASSWORD  string `json:"password" form:"password"`
	FIRSTNAME string `json:"firstname" form:"firstname"`
	LASTNAME  string `json:"lastname" form:"lastname"`
}

//The request should contain the everything derived
//in the struct
func NewAccount(Request *http.Request) Account {
	NewAccount := Account{}
	NewAccount.EMAIL = Request.FormValue("email")
	NewAccount.PASSWORD = Request.FormValue("password")
	NewAccount.FIRSTNAME = Request.FormValue("firstname")
	NewAccount.LASTNAME = Request.FormValue("lastname")
	return NewAccount
}

func EmptyAccount() Account {
	return Account{}
}
