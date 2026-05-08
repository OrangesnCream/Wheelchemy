using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class DialoguePlayer : MonoBehaviour
{
  
    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private TextMeshProUGUI name;
    private int dialogueIndex=0;
    //GameData.activeCustomer
    void Start()
    {
        name.text=GameData.activeCustomer.customerName;
        LoadNextLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLine()
    {
        if (GameData.customerResponse==0)
        {
            if (dialogueIndex>GameData.activeCustomer.happyDialogue.Count()-1)
            {
                return;
            }
            output.text=GameData.activeCustomer.happyDialogue[dialogueIndex];
        }
        if (GameData.customerResponse==1)
        {
            if (dialogueIndex>GameData.activeCustomer.sadDialogue.Count()-1)
            {
                return;
            }
            output.text=GameData.activeCustomer.sadDialogue[dialogueIndex];
        }
        if (GameData.customerResponse == 2)
        {
            if (dialogueIndex>GameData.activeCustomer.angryDialogue.Count()-1)
            {
                return;
            }
            output.text=GameData.activeCustomer.angryDialogue[dialogueIndex];
        }
        dialogueIndex++;
  
    }
}
