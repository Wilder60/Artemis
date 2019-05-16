package crypto

import (
	"crypto/aes"
	"crypto/cipher"
	"crypto/rand"
	"encoding/base64"
	"errors"
	"io"
)

//Randomly Generated 32bit key
var key = []byte(/*Your key here*/)

//Encrypt Will encrypt the inputed string using AES256 encryption
//Parameters:
//		password -> The string to encrypt
//Returns:
//		The Encrypted string and nil if no error occured
//		else empty string and the error
func Encrypt(password string) (string, error) {
	plaintext := []byte(password)
	AESblock, err := aes.NewCipher(plaintext)
	if err != nil {
		return "", err
	}

	cipherText := make([]byte, aes.BlockSize+len(plaintext))
	iv := cipherText[:aes.BlockSize]

	if _, err = io.ReadFull(rand.Reader, iv); err != nil {
		return "", nil
	}

	stream := cipher.NewCFBEncrypter(AESblock, iv)
	stream.XORKeyStream(cipherText[aes.BlockSize:], plaintext)

	//returns to base64 encoded string
	cipherString := base64.StdEncoding.EncodeToString(cipherText)

	return cipherString, nil
}

//Decrypt Decrypts the inputed string and returns the byte array of plaintext
//Parameters:
//		cipherString -> the Encrypted string
//Returns:
//		If no error, the decoded array and nil
//		Else nil and the error
func Decrypt(cipherString string) ([]byte, error) {
	cipherText, err := base64.StdEncoding.DecodeString(cipherString)
	if err != nil {
		return nil, err
	}

	block, err := aes.NewCipher(key)
	if err != nil {
		return nil, err
	}

	if len(cipherText) < aes.BlockSize {
		return nil, errors.New("ciphertext block size is too short")
	}
	iv := cipherText[:aes.BlockSize]
	cipherText = cipherText[aes.BlockSize:]

	stream := cipher.NewCFBDecrypter(block, iv)

	stream.XORKeyStream(cipherText, cipherText)
	return cipherText, nil
}
