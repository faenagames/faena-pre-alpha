using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TheySaidDisplay : MonoBehaviour
{
    private Text text;
    private void Awake() {
        text = this.GetComponent<Text>();
        PhraseChecker.phraseFoundDelegate += DisplayResponseText;
    }

    public void DisplayResponseText(string response){
        text.text = "They Said: " + response;
    }

    private void OnDestroy() {
        PhraseChecker.phraseFoundDelegate -= DisplayResponseText;
    }
}
