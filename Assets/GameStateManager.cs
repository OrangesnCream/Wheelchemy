using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TheWheel wheel;
    public Cauldron thePot;
    public ItemInventory itemInv;
    public CustomerList wallets;

    private HashSet<string> usedItems = new HashSet<string>();


    private List<(string name,int potency)> currentItems=new List<(string name, int potency)>();
    private Potion theDrink;

    void Start()
    {
        SimulateCustomerPick();
        currentItems=GameData.itemMenuSelections;
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
        theDrink=thePot.Brew();
        CheckWithCustomer();
        Debug.Log("Customer response (0 good, 1 sad, 2 mad):"+GameData.customerResponse);
        LoadNextScene();
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
    public void CheckWithCustomer()
    {
        //public static int customerResponse;//0 happy, 1 sad, 2 angry
        int response=1;
        foreach(EffectObject effect in theDrink.potionEffects)
        {
            foreach(EffectObject reqEffect in GameData.activeCustomer.requestedEffects)
            {
                if (reqEffect == effect)
                {
                    response=0;
                }
            }
            foreach(EffectObject unwantedEffect in GameData.activeCustomer.unwantedEffects)
            {
                if (unwantedEffect == effect)
                {
                    response=2;
                }
            }
        }
        GameData.customerResponse=response;
        GameData.newPotion=theDrink;
    }
    public void SimulateCustomerPick()
    {

        GameData.activeCustomer= wallets.GetByName("Bob");
    }
    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }
}
