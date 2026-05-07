using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Items", menuName = "Inventory")]
public class ItemInventory : ScriptableObject
{
    public ItemObject[] items;

    public ItemObject GetByName(string name)
    {
        foreach (ItemObject item in items)
            if (item.itemName == name) return item;
        Debug.Log("Item not found");
        return null;
    }
}
