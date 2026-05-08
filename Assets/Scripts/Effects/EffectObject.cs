using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="newEffect",menuName="Effect")]
public class EffectObject : ScriptableObject
{
   public string effectName;
    public Sprite icon;
    public ItemObject largeItem;
    public ItemObject smallItem;
}
