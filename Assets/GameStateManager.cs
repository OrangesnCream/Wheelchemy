using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TheWheel wheel;
    public Cauldron thePot;
    public ItemInventory itemInv;

    //check if we have chosen the items first
    private bool wheelScene=false;
    private bool sceneStarted=false;


    private HashSet<string> usedItems = new HashSet<string>();


    private List<(string name,int potency)> currentItems=new List<(string name, int potency)>();
    private (string reqEffect,int reqPotency) testRequest=("Slow",3);


    void Start()
    {
        GatherItems();
        StartCoroutine(WaitForMapping());
    }
    IEnumerator WaitForMapping()
    {
        yield return new WaitUntil(() => wheel._valueMappings.Count > 0);
        wheel.GetComponentInChildren<IngredientIcons>().SetImages();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void wheelFinished()
    {
        
        wheel.Reset();
        for(int i = 0; i < 4; i++)
        {
            thePot.AddIngredient(currentItems[i].name,wheel.returnedArray[i]);
        }
        thePot.testPrint();
        GatherItems();
        wheel.GetComponentInChildren<IngredientIcons>().SetImages();


    }
    public string GetActiveIngredient(int index)
    {
        if (index > 4)
        {
            Debug.Log("index too large");
            return null;
        }
        return currentItems[index].name;
    }
    private void GatherItems()
    {
       //replace with an actual call from the UI that returns the user selection 
        currentItems.Clear();
        int listCount=0;
        while(listCount<4){
            ItemObject temp= ScriptableObject.CreateInstance<ItemObject>();
            temp=itemInv.GetRandom();
                currentItems.Add((temp.itemName,1));
                usedItems.Add(temp.itemName);
                listCount++;
        }

    }
}
