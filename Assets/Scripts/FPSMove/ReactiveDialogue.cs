using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveDialogue : ReactiveTarget
{
    public override void OnRayClick()
    {
        Debug.Log("Clicked Person");
        GameReference.self.StartDialogue();
    }
}
