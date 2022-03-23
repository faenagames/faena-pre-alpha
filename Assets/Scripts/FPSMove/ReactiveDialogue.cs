using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveDialogue : ReactiveTarget
{
    [SerializeField]
    private AudioManager audioManager;
    public override void OnRayClick()
    {
        Debug.Log("Clicked Person");
        GameReference.self.StartDialogue();
        audioManager.PlaySound("Assets/Audio/testvoice");
    }
}
