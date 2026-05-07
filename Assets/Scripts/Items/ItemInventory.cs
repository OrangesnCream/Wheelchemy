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
        Debug.Log("Item not found: "+name);
        return null;
    }
    public ItemObject GetRandom()
    {
        if (items == null || items.Length == 0) return null;
        return items[Random.Range(0, items.Length-1)];
    }
}
