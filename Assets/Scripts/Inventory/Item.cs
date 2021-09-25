using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "Inventory Item", order = 1)]
[System.Serializable]
public class Item : ScriptableObject
{
    public string itemName;
    public itemType type;
    public Sprite icon;
    public enum itemType
    {
        consumable,
        useable,
        key
    }
}
