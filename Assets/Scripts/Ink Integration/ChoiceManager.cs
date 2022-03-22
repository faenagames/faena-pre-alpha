using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using GoogleCloudStreamingSpeechToText;
using System.Text;

public class ChoiceManager : MonoBehaviour
{
    public Text choiceDebugAlert;
    public bool canChoose = false;
    private List<Choice> availableChoices;
    private void Start()
    {
        InkManager.onChoiceAvailable += AwaitPlayerInput;
        StreamingRecognizer.finalResultDelegate += ReceiveTextFromSpeech;
        availableChoices = new List<Choice>();
    }

    void AwaitPlayerInput(List<Choice> choices)
    {
        canChoose = true;
        choiceDebugAlert.text = "Hold down G and speak!";
        availableChoices = choices;
    }

    private void OnDisable()
    {
        InkManager.onChoiceAvailable -= AwaitPlayerInput;
    }

    private void ReceiveTextFromSpeech(string text)
    {
        if (canChoose)
            MakeChoice(text);
    }

    private void MakeChoice(string text)
    {
        canChoose = false;
        bool match = false;
        text = text.ToLower();

        Debug.Log("I heard: " + text);
        for (int i = 0; i < availableChoices.Count; ++i)
        {
            string choice = StripPunctuation(availableChoices[i].text);
            if( choice == text)
            {
                Debug.Log("Match found: " + i);
                match = true;
                InkManager.active.ChooseAtIndex(i);
            }
        }

        if (!match)
        {
            canChoose = true;
            choiceDebugAlert.text = "I didn't hear that! Hold down G and speak!";
        }
    }

    private string StripPunctuation(string s)
    {
        var sb = new StringBuilder();
        foreach (char c in s)
        {
            if (!char.IsPunctuation(c))
                sb.Append(c);
        }
        return sb.ToString();
    }

    private void OnDestroy()
    {
        StreamingRecognizer.finalResultDelegate -= ReceiveTextFromSpeech;
        InkManager.onChoiceAvailable -= AwaitPlayerInput;
    }
}
