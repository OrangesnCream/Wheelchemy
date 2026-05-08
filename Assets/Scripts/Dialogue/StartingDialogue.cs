using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class StartingDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private TextMeshProUGUI buyerName;
    [SerializeField] private CustomerList buyers;
    [SerializeField] private GameObject endButton;
    [SerializeField] private GameObject nxtButton;
    [SerializeField] private GameObject endSceneButton;
    private int dialogueIndex=0;
    void Start()
    {
        
        //set up the whole scene 
        if (buyers.customers.Count() > GameData.gameProg)
        {
            GameData.activeCustomer=buyers.customers[GameData.gameProg];
            GameData.itemMenuSelections.Clear();
        }
        else
        {
            //exit scene for end screen
            output.text="There are no more customers, you close up for the day";
            //reveal end button 
            endButton.SetActive(true);
            nxtButton.SetActive(false);
            return;
        }
        buyerName.text=GameData.activeCustomer.customerName;
        LoadNextLine();
        //first set the right customer and then load all their data in to the scene
        //check if there are any customers left, if not we play some dialogue aknowledging that and go to the end screen;
        //other than that and reseting everything it should just be playing dialogue. 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLine()
    {
        
            if (dialogueIndex>GameData.activeCustomer.startingDialogue.Count()-1)
            {
                //play +money animation and then set up next customer
                
                nxtButton.SetActive(false);
                endSceneButton.SetActive(true);
                return;
            }
            output.text=GameData.activeCustomer.startingDialogue[dialogueIndex];
        
        dialogueIndex++;
  
    }
}
