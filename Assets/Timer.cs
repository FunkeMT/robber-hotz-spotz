using System;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class Timer : MonoBehaviour {

    double timestamp = (int)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        double now = (int)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        if (now - timestamp > 2) {
            GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;
        }
        if (now - timestamp > 3)
        {
            timestamp = (int)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
            GetComponent<SpatialMappingManager>().DrawVisualMeshes = false;
        }
    }
}
