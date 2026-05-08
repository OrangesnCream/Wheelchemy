using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newItem",menuName="Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    //iteractions done at the cauldron and stored seperately 
}
