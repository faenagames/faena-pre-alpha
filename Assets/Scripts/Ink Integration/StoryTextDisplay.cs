using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextDisplay : MonoBehaviour
{
    private Text textDisplay;
 

    // Start is called before the first frame update
    void Awake()
    {
        textDisplay = this.GetComponent<Text>();
        InkManager.storyTextChangeEvent += UpdateText;
    }

    // Update is called once per frame
    void UpdateText(string newText)
    {
        textDisplay.text = newText;
    }

    private void OnDestroy()
    {
        InkManager.storyTextChangeEvent -= UpdateText;
    }
}
