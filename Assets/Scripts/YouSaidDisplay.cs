using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleCloudStreamingSpeechToText;
public class YouSaidDisplay : MonoBehaviour
{
    private Text text;
  private void Awake() {
      text = GetComponent<Text>();
      StreamingRecognizer.finalResultDelegate += DisplayText;
  }

  public void DisplayText(string textToDisplay){
      this.text.text = "You Said: " +  textToDisplay;
  }

  private void OnDestroy() {
      StreamingRecognizer.finalResultDelegate -= DisplayText;
  }
}
