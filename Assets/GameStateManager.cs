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
    private HashSet<string> usedItems = new HashSet<string>();


    private List<(string name,int potency)> currentItems=new List<(string name, int potency)>();
    private (string reqEffect,int reqPotency) testRequest=("Slow",3);

    void Start()
    {
        GatherItems(testRequest.reqEffect);
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
        GatherModifiers();
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
    private void GatherItems(string effect)
    {
       
        currentItems.Clear();
        int listCount=0;
        while(listCount<4){
            ItemObject temp= ScriptableObject.CreateInstance<ItemObject>();
            temp=itemInv.GetRandom();
            if (usedItems.Contains(temp.itemName)||temp.itemName=="Purify"
            ||temp.itemName=="Concentrate"||temp.itemName=="Stabilize"||temp.itemName=="Distill")
            {
                
                continue;
            }
            if (temp.itemEffect == effect && listCount == 0)
            {
                currentItems.Add((temp.itemName,1));
                usedItems.Add(temp.itemName);
                listCount++;
                
                continue;
            }
            if (listCount>0)
            {
                
                currentItems.Add((temp.itemName,1));
                usedItems.Add(temp.itemName);
                listCount++;
            }

        }

    }
    private void GatherModifiers()
    {
        currentItems.Clear();
        currentItems.Add(("Purify",1));
        currentItems.Add(("Concentrate",1));
        currentItems.Add(("Stabilize",1));
        currentItems.Add(("Distill",1));
    }
}
