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

//CreateToken Creates a new JWT token that will allow the user to make requests to the server
//Paraemters:
//		AccountToTokenize -> The user account to generate the Token
//Returns:
//		If no error occured the token string and nil
//		else an empity string and the error
func CreateToken(AccountToTokenize account.Account) (string, error) {
	claims := artemisClaims{
		AccountToTokenize.ID,
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

//ValidateToken Will parse the Token an check to see if the token is valid
//Parameters:
//		tokenString-> The jwt token to be validated
//Returns:
//		nil if token is valid
//		else the error
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
