package jwt

import (
	"Artemis/App/Account"
	"fmt"

	"github.com/dgrijalva/jwt-go"
)

type artemisClaims struct {
	Email     string `json:"email,omitempty"`
	FirstName string `json:"firstname,omitempty"`
	Lastname  string `json:"lastname,omitempty"`
	jwt.StandardClaims
}

var signingKey = "AllYourBase"

//CreateToken Creates a new JWT token that will allow the user to make requests to
//routes other then the login route
func CreateToken(AccountToTokenize account.Account) (string, error) {
	claims := artemisClaims{
		AccountToTokenize.Id,
		AccountToTokenize.Firstname,
		AccountToTokenize.Lastname,
		jwt.StandardClaims{
			ExpiresAt: 0,
			Issuer:    "Artemis",
		},
	}

	Token := jwt.NewWithClaims(jwt.SigningMethodHS256, claims)
	SignedString, err := Token.SignedString([]byte(signingKey))
	if err != nil {
		return "", err
	}
	return SignedString, nil
}

//ValidateToken function to Parse and validate that a token that is sent to the
//server is legit
func ValidateToken(tokenString string) error {

	token, err := jwt.ParseWithClaims(tokenString, &artemisClaims{}, func(token *jwt.Token) (interface{}, error) {
		if _, ok := token.Method.(*jwt.SigningMethodHMAC); !ok {
			return nil, fmt.Errorf("Unexpected siging method")
		}
		return []byte(signingKey), nil
	})

	if _, ok := token.Claims.(jwt.MapClaims); ok && token.Valid {
		return nil
	}
	return err
}

//ReturnEmailAddress stuff
func ReturnEmailAddress(TokenString string) (string, error) {
	token, err := jwt.ParseWithClaims(TokenString, &artemisClaims{}, func(token *jwt.Token) (interface{}, error) {
		return []byte(signingKey), nil
	})

	claims, ok := token.Claims.(*artemisClaims)
	if ok != true {
		return "", err
	}
	return claims.Id, nil
}
