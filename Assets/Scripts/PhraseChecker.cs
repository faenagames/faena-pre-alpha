using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleCloudStreamingSpeechToText;

public class PhraseChecker : MonoBehaviour
{
    public static PhraseChecker active;
    private Dictionary<string,string> phraseBook;
    public delegate void OnPhraseFound(string response);
    public static OnPhraseFound phraseFoundDelegate;

    private void initDictionary(){
        phraseBook = new Dictionary<string, string>(){
            {"hello", "hey!"},
            {"how are you", "I'm doing ok"},
            {"how can i help", "I need object"},
            {"what do you want", "I need object"},
            {"today is nice", "yes the weather is beautiful"},
            {"here is object", "oh wow, just what I needed!"}
        };
    }

    private void Awake() {
        if(active == null){
            active = this;
        }
        StreamingRecognizer.finalResultDelegate += CheckPhrases;
    }
    // Start is called before the first frame update
    void Start()
    {
        initDictionary();
    }

    public void CheckPhrases(string text){
        if(phraseBook.ContainsKey(text)){
            phraseFoundDelegate(phraseBook[text]);
        }
    }

    private void OnDestroy() {
        StreamingRecognizer.finalResultDelegate -= CheckPhrases;
    }
}
