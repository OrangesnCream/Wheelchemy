using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    // Start is called before the first frame update
    private List<(string name,int potency)> ingredientList=new List<(string name, int potency)>();
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddIngredient(string newName, int newPotency)
    {
        ingredientList.Add((newName,newPotency));
    }
    public void testPrint()
    {
        for (int i=0; i<ingredientList.Count;i++)
        {
             Debug.Log("Name "+ingredientList[i].name);
             Debug.Log("potency "+ingredientList[i].potency);
        }
    }
    //takes all the ingredient math and spits out a potion 

    public void Brew()
    {
        //might need to change plan if doing multiple rounds
        



        //check all ingredients for interactions 
        //add all effects to the potion 
        
        //send to GSM
    
    }



}
public class Potion
{
    //name is concat,  "Elixir(sweet medicine), Draught(beer), Tincture(extract in alcohol), Brew(evil), Mixture(neutral)," + " of " + majorEffect
    public string name;
    public string majorEffect;
    public string[] minorEffects;//only the relevant ones  
    public string[] badEffects;//really bad ones
    public List<(string effect,int potency)> effectsList;
}

