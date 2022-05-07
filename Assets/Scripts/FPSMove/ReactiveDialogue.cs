using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveDialogue : ReactiveTarget
{
    public string inkKnot = "";
    public override void OnRayClick()
    {
        Debug.Log("Clicked Person");
        if (inkKnot != "")
        {
            GameReference.self.StartDialogue(inkKnot);
        }
        else
        {
            GameReference.self.StartDialogue();
        }
    }
}
