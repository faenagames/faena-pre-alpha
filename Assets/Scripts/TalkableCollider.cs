using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleCloudStreamingSpeechToText;

public class TalkableCollider : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
       Debug.Log("trigger entered");
       StreamingRecognizer.active.StartListening();
   }

   private void OnTriggerExit(Collider other) {
       Debug.Log("trigger exit");
       StreamingRecognizer.active.StopListening();
   }
}
