using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleCloudStreamingSpeechToText;

public class InputManager : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("input manager awake!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            StreamingRecognizer.active.StartListening();

        if (Input.GetKeyUp(KeyCode.G))
            StreamingRecognizer.active.StopListening();
    }
}
