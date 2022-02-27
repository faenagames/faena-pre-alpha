using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameReference : MonoBehaviour
{
    //singleton structure thing
    public static GameReference self;


    private List<GameObject> itemIcons = new List<GameObject>();
    public GameObject canvasInventory;
    public GameObject prefabIcon;
    public GameObject optionsPanel;

    //Canvas element that shows when aiming at interactive things
    public GameObject AimPopup;
    public TextMeshProUGUI AimPopupText;


    //Dialogue window
    public GameObject DialoguePanel;


    //freezes player during dialogues/menus
    public static bool freezePlayerMovement = false;

    private void Start()
    {
        //LoadGame();
        AimPopup.SetActive(false);
        if (self == null)
        {
            self = this;
            Debug.Log("GameRef Self Set");
        }
        else
        {
            Destroy(this);
            Debug.Log("Destroying Duplicate GameRef");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsPanel.activeSelf)
            {
                CloseOptions();
            }
            else
            {
                OpenOptions();
            }
        }
    }

    private void SetFreeze()
    {
        if (!DialoguePanel.active && !optionsPanel.active)
        {
            freezePlayerMovement = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            freezePlayerMovement = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        SetFreeze();
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        SetFreeze();
    }
    public void StartDialogue()
    {
        DialoguePanel.SetActive(true);
        SetFreeze();
    }

    public void CloseDialogue()
    {
        DialoguePanel.SetActive(false);
        SetFreeze();
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
