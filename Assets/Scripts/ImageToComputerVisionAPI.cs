using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

public class ImageToComputerVisionAPI : MonoBehaviour {

    string VISIONKEY = "2d5c02b414d4458b8e30f4b7fda51cd2"; // replace with your Computer Vision API Key

    string emotionURL = "https://api.projectoxford.ai/vision/v1.0/analyze?visualFeatures=Description";

    public string fileName { get; private set; }
    string responseData;

    // Use this for initialization
    //void Start () {
	//    fileName = Path.Combine(Application.streamingAssetsPath, "cityphoto.jpg"); // Replace with your file
    //}
	
	// Update is called once per frame
	public void Call (string path) {
        fileName = path;
        StartCoroutine(GetVisionDataFromImages());
        // This will be called with your specific input mechanism
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(GetVisionDataFromImages());
        //}

    }
    /// <summary>
    /// Get emotion data from the Cognitive Services Emotion API
    /// Stores the response into the responseData string
    /// </summary>
    /// <returns> IEnumerator - needs to be called in a Coroutine </returns>
    IEnumerator GetVisionDataFromImages()
    {
        byte[] bytes = File.ReadAllBytes(fileName);

        var headers = new Dictionary<string, string>() {
            { "Ocp-Apim-Subscription-Key", VISIONKEY },
            { "Content-Type", "application/octet-stream" }
        };

        WWW www = new WWW(emotionURL, bytes, headers);

        yield return www;
        responseData = www.text; // Save the response as JSON string
        GetComponent<ParseComputerVisionResponse>().ParseJSONData(responseData);
    }
}
