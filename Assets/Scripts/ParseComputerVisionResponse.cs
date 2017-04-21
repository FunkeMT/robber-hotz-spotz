using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;

public class ParseComputerVisionResponse : MonoBehaviour {

    public List<FoundImageObject> imageCategories {  get; private set; }
    public GameObject sushi;

	// Use this for initialization
	void Start () {
        imageCategories = new List<FoundImageObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Parse JSON data from the response
    /// Pass in the response from the API call
    /// </summary>
    /// <param name="respString"></param>
    public void ParseJSONData(string respString)
    {
        JSONObject dataArray = new JSONObject(respString);
        //FoundImageObject _imageObject = ConvertObjectToFoundImageObject(dataArray);
        Debug.Log(dataArray["description"]["captions"][0]["text"]);
        GetComponent<TextToSpeechManager>().SpeakText(dataArray["description"]["captions"][0]["text"].ToString());
        sushi.SetActive(false);
    }
    /// <summary>
    /// A helper class for converting the JSON object into a Face Object
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private FoundImageObject ConvertObjectToFoundImageObject(JSONObject obj)
    {

        JSONObject _categories = obj.list[0]; // Get the list of categories
        return new FoundImageObject(_categories);
    }
    
}
