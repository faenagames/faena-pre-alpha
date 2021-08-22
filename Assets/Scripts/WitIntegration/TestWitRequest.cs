using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.Networking;

using UnityEngine.UI;
using UnityEngine;

public class TestWitRequest : MonoBehaviour
{
    private string url = "https://api.wit.ai/speech";
    private string accessToken = Auth.GetApiKey();
    [SerializeField]
    private Text debugDisplay;

    public delegate void OnSuccessfulResponse(string text);
    public static OnSuccessfulResponse responseDelegate;

    public static TestWitRequest testWitRequest;

    private void Awake() {
        testWitRequest = this;
    }

    public void MakeRequest(){
        //Application.persistenDataPath on windows is usually %userprofile%\AppData\LocalLow\<companyname>\<productname>
        string testFilepath = Path.Combine(Application.persistentDataPath, "testAudio.wav");

        FileStream fileStream = new FileStream(testFilepath, FileMode.Open, FileAccess.Read);
        BinaryReader filereader = new BinaryReader(fileStream);
        byte[] BA_AudioFile = filereader.ReadBytes((Int32)fileStream.Length);
        fileStream.Close();
        filereader.Close();

        UnityWebRequest www =  UnityWebRequest.Post(url,"");
        www.SetRequestHeader("Authorization", "Bearer " + accessToken);
        www.SetRequestHeader("Content-Type", "audio/wav");
        www.uploadHandler = new UploadHandlerRaw(BA_AudioFile);
        StartCoroutine(onResponse(www));
    }

    private IEnumerator onResponse(UnityWebRequest www){
        Debug.Log("sending " + www.uploadHandler.data);
        DisplayText("Making Request...");
        yield return www.SendWebRequest();
        if(www.result == UnityWebRequest.Result.ConnectionError){
            Debug.Log("Network err: " + www.GetResponseHeader(""));
            DisplayText("Network err: " + www.GetResponseHeader(""));
        }else{
            Debug.Log("SUCCESS: " + www.downloadHandler.text);
            Response res  = new Response();
            res = JsonUtility.FromJson<Response>(www.downloadHandler.text);
            DisplayText(res.text);
            responseDelegate(res.text);
        }
    }

    private void DisplayText(string text){
        if(debugDisplay){debugDisplay.text = text; }
    }
}
