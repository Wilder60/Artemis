package JWT

import (
	"ArtemisServer/UserAccount"
	"errors"
	"net/http"

	"github.com/dgrijalva/jwt-go"
)

var signingKey = []byte("RemeberChangeThisToSomeThingElse")

//Creates a new JWT token that will allow the user to make requests to
//routes other then the login route
func CreateToken(AccountToTokenize UserAccount.Account) (string, error) {
	NewToken := jwt.New(jwt.SigningMethodHS256)
	claims := NewToken.Claims.(jwt.MapClaims)

	claims["Email"] = AccountToTokenize.EMAIL
	claims["exp"] = -1
	claims["Issuer"] = "Artemis"

	NewTokenString, err := NewToken.SignedString(signingKey)
	if err != nil {
		return "", err
	}
	return NewTokenString, nil
}

//function to Parse and validate that a token that is sent to the
//server is legit
func ValidateToken(Request *http.Request) error {
	if Request.Header["Token"] == nil {
		return errors.New("Missing Authentication Token")
	}

	IncomingToken, err := jwt.Parse(Request.Header["Token"][0], func(token *jwt.Token) (interface{}, error) {
		if _, ok := token.Method.(*jwt.SigningMethodHMAC); !ok {
			return nil, errors.New("Error Parsing Token")
		}
		return signingKey, nil
	})

	if err != nil {
		return err
	}
	if IncomingToken.Valid {
		return nil
	}
	return errors.New("Expited Token")
}

func ReturnEmailAddress(Request *http.Request) (string, error) {
	err := ValidateToken(Request)
	if err != nil {
		return "", err
	}
	return "", nil
}
