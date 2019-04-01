package ArtemisVoice

import (
	"context"
	"fmt"
	"io/ioutil"
	"log"

	texttospeech "cloud.google.com/go/texttospeech/apiv1"
	texttospeechpb "google.golang.org/genproto/googleapis/cloud/texttospeech/v1"
)

func ConvertTextToSpeech(a_StringToConvert string, a_ReturnLanguage string, a_PlayBackVoice texttospeechpb.SsmlVoiceGender) {
	//create a new context
	ctx := context.Background()
	client, err := texttospeech.NewClient(ctx)
	if err != nil {
		log.Fatal(err)
	}

	req := texttospeechpb.SynthesizeSpeechRequest{
		Input: &texttospeechpb.SynthesisInput{
			InputSource: &texttospeechpb.SynthesisInput_Text{Text: a_StringToConvert},
		},
		Voice: &texttospeechpb.VoiceSelectionParams{
			LanguageCode: a_ReturnLanguage,
			SsmlGender:   a_PlayBackVoice,
		},
		AudioConfig: &texttospeechpb.AudioConfig{
			AudioEncoding: texttospeechpb.AudioEncoding_MP3,
		},
	}

	resp, err := client.SynthesizeSpeech(ctx, &req)
	if err != nil {
		log.Fatal(err)
	}

	filename := "output.mp3"
	err = ioutil.WriteFile(filename, resp.AudioContent, 0644)
	if err != nil {
		log.Fatal(err)
	}
	fmt.Printf("Audio content written to file: %v\n", filename)

}
