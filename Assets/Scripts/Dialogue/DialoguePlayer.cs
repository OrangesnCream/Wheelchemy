using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Net;
public class DialoguePlayer : MonoBehaviour
{
  
    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private GameObject nxtButton;
    [SerializeField] private GameObject nxtCustomerButton;
    [SerializeField] private GameObject tryAgainButton;
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
                GameData.money+=50;
                //play +money animation and then set up next customer
                
                nxtButton.SetActive(false);
                nxtCustomerButton.SetActive(true);
                return;
            }
            output.text=GameData.activeCustomer.happyDialogue[dialogueIndex];
        }
        if (GameData.customerResponse==1)
        {
            if (dialogueIndex>GameData.activeCustomer.sadDialogue.Count()-1)
            {
                //reveal rejection buttons 
                nxtButton.SetActive(false);
                nxtCustomerButton.SetActive(true);
                tryAgainButton.SetActive(true);
                return;
            }
            output.text=GameData.activeCustomer.sadDialogue[dialogueIndex];
        }
        if (GameData.customerResponse == 2)
        {
            if (dialogueIndex>GameData.activeCustomer.angryDialogue.Count()-1)
            {
                //Play -money animation and set up next customer;
               
                nxtButton.SetActive(false);
                nxtCustomerButton.SetActive(true);
                GameData.money-=50;
                return;
            }
            output.text=GameData.activeCustomer.angryDialogue[dialogueIndex];
        }
        dialogueIndex++;
  
    }
    public void SetUpNextCustomer()
    {
        GameData.gameProg++;
        //make customer read this number at the start
        //feel like i'm missing something tbh but it might just be that simple.
    }
}
