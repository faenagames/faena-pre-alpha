using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveDialogue : ReactiveTarget
{
    [SerializeField]
    private DialoguePlayer dialoguePlayer;
    public override void OnRayClick()
    {
        Debug.Log("Clicked Person");
        GameReference.self.StartDialogue();
        dialoguePlayer.PlaySound("Assets/Audio/testvoice");
    }
}
