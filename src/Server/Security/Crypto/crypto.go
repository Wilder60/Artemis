package crypto

import (
	"crypto/aes"
	"crypto/cipher"
	"crypto/rand"
	"encoding/base64"
	"errors"
	"io"
)

var key = []byte("!Tr2PFFJQqs7-y3beej*%CJgwwmX=%Pj")

//Encrypt Stuff to encrypt
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

//Decrypt Decrypts the cipherText
func Decrypt(cipherString string) (string, error) {
	cipherText, err := base64.StdEncoding.DecodeString(cipherString)
	if err != nil {
		return "", err
	}

	block, err := aes.NewCipher(key)
	if err != nil {
		return "", err
	}

	if len(cipherText) < aes.BlockSize {
		return "", errors.New("ciphertext block size is too short")
	}
	iv := cipherText[:aes.BlockSize]
	cipherText = cipherText[aes.BlockSize:]

	stream := cipher.NewCFBDecrypter(block, iv)

	stream.XORKeyStream(cipherText, cipherText)
	plaintext := string(cipherText)
	return plaintext, nil
}
