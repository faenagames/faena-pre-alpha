using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is copied heavily from Dimitri @ http://www.41post.com/4884/programming/unity-capturing-audio-from-a-microphone
// I have adapted it to record the clip to wav file
//  --g. hutchision

public class MicrophoneCapture : MonoBehaviour
{
    private bool micConnected = false;

    //The maximum and minimum available recording frequencies  
    private int minFreq;
    private int maxFreq;

    //A handle to the attached AudioSource  
    private AudioClip newClip;

    //Use this for initialization  
    void Start()
    {
        //Check if there is at least one microphone connected  
        if (Microphone.devices.Length <= 0)
        {
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");
        }
        else //At least one microphone is present  
        {
            //Set 'micConnected' to true  
            micConnected = true;

            //Get the default microphone recording capabilities  
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...  
            if (minFreq == 0 && maxFreq == 0)
            {
                //...meaning 44100 Hz can be used as the recording sampling rate  
                maxFreq = 44100;
            }
        }
    }

    public void StartRecording(){
        newClip = Microphone.Start(null, false, 15, maxFreq);
    }

    public void StopRecording(){
        Microphone.End(null);
        SavWav.Save("testAudio", newClip);
    }
}
