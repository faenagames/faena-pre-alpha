using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMatcher : MonoBehaviour
{
    public string wordToMatch;
   
   private void Start() {
       TestWitRequest.responseDelegate += MatchWord;
   }
   
   public void MatchWord(string word){
       if(wordToMatch.ToLower() == word.ToLower()){
           Debug.Log("SUCCESS MATCH");
       }else{
           Debug.Log("INCORRECT WORD");
       }
   }
}
