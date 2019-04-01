package JWT

import (
	"Artemis/App/UserAccount"
	"time"

	"github.com/dgrijalva/jwt-go"
)

type ArtemisClaims struct {
	Email     string `json:"email,omitempty"`
	FirstName string `json:"firstname,omitempty"`
	Lastname  string `json:"lastname,omitempty"`
	jwt.StandardClaims
}

var signingKey = []byte("RemeberChangeThisToSomeThingElse")

//Creates a new JWT token that will allow the user to make requests to
//routes other then the login route
func CreateToken(AccountToTokenize UserAccount.Account) (string, error) {
	claims := ArtemisClaims{
		AccountToTokenize.EMAIL,
		AccountToTokenize.FIRSTNAME,
		AccountToTokenize.LASTNAME,
		jwt.StandardClaims{
			Audience:  AccountToTokenize.EMAIL,
			ExpiresAt: -1,
			IssuedAt:  time.Now().Unix(),
			Issuer:    "Artemis",
		},
	}

	Token := jwt.NewWithClaims(jwt.SigningMethodES256, claims)
	SignedString, err := Token.SignedString(signingKey)
	if err != nil {
		return "", err
	}
	return SignedString, nil
}

//function to Parse and validate that a token that is sent to the
//server is legit
func ValidateToken(TokenString string) error {
	token, err := jwt.ParseWithClaims(TokenString, &ArtemisClaims{}, func(token *jwt.Token) (interface{}, error) {
		return []byte(signingKey), nil
	})

	if _, ok := token.Claims.(*ArtemisClaims); ok && token.Valid {
		return nil
	}
	return err
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
