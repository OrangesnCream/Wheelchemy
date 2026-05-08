using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Customer")]
public class Customer : ScriptableObject
{
    public string customerName;
    public Sprite Icon;
    public string[] startingDialogue;
    public string[] happyDialogue;
    public string[] sadDialogue;
    public string[] angryDialogue;
    public EffectObject[] requestedEffects;
    public EffectObject[] unwantedEffects;

}
