using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string address)
    {
        StartCoroutine(LoadAndPlay(address));
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
    private IEnumerator LoadAndPlay(string address)
    {
        var currentOperationHandle = Addressables.LoadAssetAsync<AudioClip>(address);
        yield return currentOperationHandle;
        var newAudioClip = currentOperationHandle.Result;
        _audioSource.clip = newAudioClip;
        _audioSource.Play();
    }
}
