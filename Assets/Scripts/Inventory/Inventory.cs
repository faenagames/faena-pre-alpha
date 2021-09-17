using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> items = new List<InventorySlot>();

    public void AddItems(Item item, int amount)
    {
        foreach(InventorySlot i in items)
        {
            if (i.GetItem() == item)
            {
                i.amount += amount;
                return;
            }
        }

        items.Add(new InventorySlot( item.itemName, amount ));
    }

    public bool RemoveItems(Item item, int amount)
    {
        //If there are more than "amount" of the item, remove "amount" from the inventory and return true. Otherwise return false.
        foreach (InventorySlot i in items)
        {
            if (i.GetItem() == item && i.amount >= amount)
            {
                i.amount -= amount;
                if (i.amount == 0)
                {
                    items.Remove(i);
                }
                return true;
            }
        }

        return false;
    }

    [System.Serializable]
    public class InventorySlot
    {
        public string itemPath;
        public int amount;

        public InventorySlot(string _itemName, int _amount)
        {
            itemPath = "Items/" + _itemName;
            amount = _amount;
        }

        public Item GetItem()
        {
            return Resources.Load<Item>(itemPath);
        }
    }
}
