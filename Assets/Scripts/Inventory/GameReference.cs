using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameReference : MonoBehaviour
{
    private List<GameObject> itemIcons = new List<GameObject>();
    public GameObject canvasInventory;
    public GameObject prefabIcon;

    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        SaveLoad.Save();
    }


    public void LoadGame()
    {
        SaveLoad.Load();
        ShowInventory(Game.current.inventory);
    }

    public void ShowInventory(Inventory inv)
    {
        foreach(GameObject g in itemIcons)
        {
            Destroy(g);
        }

        itemIcons = new List<GameObject>();

        int x = 0;
        foreach(Inventory.InventorySlot i in inv.items)
        {
            GameObject icon = Instantiate(prefabIcon, canvasInventory.transform);
            itemIcons.Add(icon);
            icon.GetComponent<Image>().sprite = i.GetItem().icon;
            icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
            x += 150;
            icon.GetComponentInChildren<TextMeshProUGUI>().text = i.amount.ToString();
        }
    }

    public void AddItem(Item item)
    {
        Debug.Log(Game.current);
        Debug.Log(Game.current.inventory);
        Debug.Log(item);
        Game.current.inventory.AddItems(item, 1);
        ShowInventory(Game.current.inventory);
    }

    public void RemoveItem(Item item)
    {
        Debug.Log(Game.current.inventory.RemoveItems(item, 1));
        ShowInventory(Game.current.inventory);
    }
}
