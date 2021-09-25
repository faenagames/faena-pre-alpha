using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Game
{
    public static Game current;
    public Inventory inventory;
    public Game ()
    {
        inventory = new Inventory();
    }
}
