using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public string popupText = "Talk";
    public virtual void OnRayClick()
    {
        Debug.Log("Clicked");
    }

    public virtual void OnRayHit()
    {
        Debug.Log("Object hit");
    }
}
