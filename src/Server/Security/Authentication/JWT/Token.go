package JWT

import (
	"Artemis/App/UserAccount"
	"fmt"

	"github.com/dgrijalva/jwt-go"
)

type ArtemisClaims struct {
	Email     string `json:"email,omitempty"`
	FirstName string `json:"firstname,omitempty"`
	Lastname  string `json:"lastname,omitempty"`
	jwt.StandardClaims
}

var signingKey = "AllYourBase"

//Creates a new JWT token that will allow the user to make requests to
//routes other then the login route
func CreateToken(AccountToTokenize UserAccount.Account) (string, error) {
	claims := ArtemisClaims{
		AccountToTokenize.EMAIL,
		AccountToTokenize.FIRSTNAME,
		AccountToTokenize.LASTNAME,
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

//function to Parse and validate that a token that is sent to the
//server is legit
func ValidateToken(tokenString string) error {

	token, err := jwt.ParseWithClaims(tokenString, &ArtemisClaims{}, func(token *jwt.Token) (interface{}, error) {
		if _, ok := token.Method.(*jwt.SigningMethodHMAC); !ok {
			return nil, fmt.Errorf("Unexpected siging method")
		}
		return []byte(signingKey), nil
	})

	if claims, ok := token.Claims.(jwt.MapClaims); ok && token.Valid {
		fmt.Println(claims["Email"])
		return nil
	} else {
		return err
	}
}

func ReturnEmailAddress(TokenString string) (string, error) {
	token, err := jwt.ParseWithClaims(TokenString, &ArtemisClaims{}, func(token *jwt.Token) (interface{}, error) {
		return []byte(signingKey), nil
	})

	claims, ok := token.Claims.(*ArtemisClaims)
	if ok != true {
		return "", err
	}
	return claims.Email, nil
}
