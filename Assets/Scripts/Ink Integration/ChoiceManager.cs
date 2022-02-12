using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using GoogleCloudStreamingSpeechToText;

public class ChoiceManager : MonoBehaviour
{
    public Text choiceDebugAlert;
    private List<Choice> availableChoices;
    private void Start()
    {
        InkManager.onChoiceAvailable += AwaitPlayerInput;
        StreamingRecognizer.finalResultDelegate += MakeChoice;
        availableChoices = new List<Choice>();
    }

    void AwaitPlayerInput(List<Choice> choices)
    {
        choiceDebugAlert.text = "Awaiting player input";
        availableChoices = choices;
        StreamingRecognizer.active.StartListening();
    }

    private void OnDisable()
    {
        InkManager.onChoiceAvailable -= AwaitPlayerInput;
    }

    private void MakeChoice(string text)
    {
        text = text.ToLower();
        StreamingRecognizer.active.StopListening();

        Debug.Log("I heard: " + text);
        for (int i = 0; i < availableChoices.Count; ++i)
        {
            if(availableChoices[i].text == text)
            {
                Debug.Log("Match found: " + i);

                InkManager.active.ChooseAtIndex(i);
            }
        }
    }

    private void OnDestroy()
    {
        StreamingRecognizer.finalResultDelegate -= MakeChoice;
        InkManager.onChoiceAvailable -= AwaitPlayerInput;
    }
}
