using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class SpeechControl : MonoBehaviour {

    public GameObject gObject;
    TextToSpeechManager textToSpeech;

    // Use this for initialization
    void Start () {        
        textToSpeech = GetComponent<TextToSpeechManager>();

    }
	
	// Update is called once per frame
	void Update () {
        if (textToSpeech.IsSpeaking())
        {
            Debug.Log("Speech Control active");
            gObject.SetActive(true);
        } else
        {
            gObject.SetActive(false);
        }        
	}
}
