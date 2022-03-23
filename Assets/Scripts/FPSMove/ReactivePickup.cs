using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactivePickup : ReactiveTarget
{
    public override void OnRayClick()
    {
        Destroy(gameObject);
        //TODO: Add thing to inventory.
    }
}
