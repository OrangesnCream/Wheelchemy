using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Effects", menuName = "Effects List")]
public class EffectList : ScriptableObject
{
    public EffectObject[] effects;

    public EffectObject GetByName(string name)
    {
        foreach (EffectObject effect in effects)
            if (effect.effectName == name) return effect;
        Debug.Log("Effect not found: "+name);
        return null;
    }
}
