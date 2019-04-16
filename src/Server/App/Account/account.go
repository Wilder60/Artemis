package account

//Account will contain all the information for a user Account
type Account struct {
	ID        string `json:"id,omitempty"`
	Email     string `json:"email,omitempty"`
	Password  string `json:"password,omitempty"`
	PageStyle string `json:"pagestyle,omitempty"`
	Firstname string `json:"firstname,omitempty"`
	Lastname  string `json:"lastname,omitempty"`
}

//EditAccount An Account that has changes inside of it i.e. new password
type EditAccount struct {
	ID              string `json:"id,omitempty"`
	Email           string `json:"email,omitempty"`
	Password        string `json:"password,omitempty"`
	PageStyle       string `json:"pagestyle,omitempty"`
	Firstname       string `json:"firstname,omitempty"`
	Lastname        string `json:"lastname,omitempty"`
	UpdatedPassword string `json:"updatedpassword,omitempty"`
}

//ConvertToAccount will convert a EditAccount struct into a Account
//Parameters:
//		UpdateAccount -> The EditAccount to be converted to an Account
//Returns:
//		Account struct containing the updated information
func ConvertToAccount(UpdateAccount EditAccount) Account {
	newAccount := Account{}
	newAccount.ID = UpdateAccount.ID
	newAccount.Email = UpdateAccount.Email
	newAccount.Password = UpdateAccount.UpdatedPassword
	newAccount.PageStyle = UpdateAccount.PageStyle
	newAccount.Firstname = UpdateAccount.Firstname
	newAccount.Lastname = UpdateAccount.Lastname
	return newAccount
}
