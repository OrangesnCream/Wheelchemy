using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelTester : MonoBehaviour
{
    // THIS IS HOW YOU LEARN TO WHEEL
    [SerializeField] private TheWheel theWheel;
    [SerializeField] private GameStateManager gameState;
    [SerializeField] private TextMeshProUGUI output;

    private void Awake()
    {
        theWheel.newDirChosen.AddListener(UpdateOutput);
    }

    private void OnDestroy()
    {
        theWheel.newDirChosen.RemoveListener(UpdateOutput);
    }

    public void UpdateOutput(WheelPayload payload)
    {
        string outputString = string.Empty;
        

        outputString += $"{gameState.GetActiveIngredient(payload.BaseValue)}????";
       

        outputString += "\nSlice multiplier: ";
        switch (payload.SliceValue)
        {
            case 1:
                outputString += "x1";
                break;
            case 2:
                outputString += "x2";
                break;
            case 3:
                outputString += "x3";
                break;
            case 4:
                outputString += "x4";
                break;
        }

        outputString += $"\nTotal value: {payload.TotalValue}";
        
        output.text = outputString;
    }
}
