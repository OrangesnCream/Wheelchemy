using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    // Start is called before the first frame update
    private List<(string name,int potency)> ingredientList=new List<(string name, int potency)>();
    private string[] potionNames={"Elixir", "Draught", "Tincture", "Brew", "Mixture"};
    public EffectList effectList;
    public ItemInventory itemInv;
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

    public Potion Brew()
    {
        //might need to change plan if doing multiple rounds
        Potion potion=new Potion();
        //check all ingredients for interactions 
        //add all effects to the potion 
        foreach( EffectObject effect in effectList.effects)
        {
            int firstInt=-1;
            int secondInt=-1;
            foreach ((string name,int potency) ingredient in ingredientList)
            {
                if (itemInv.GetByName(ingredient.name)==effect.largeItem)
                {
                    firstInt=ingredient.potency;
                }
                if (itemInv.GetByName(ingredient.name)==effect.smallItem)
                {
                    secondInt=ingredient.potency;
                }
            }
            if(firstInt>secondInt){
                potion.potionEffects.Add(effect);
            }

        }
        potion.name=potionNames[Random.Range(0,potionNames.Count())];
        potion.name+=" of "+ effectList.effects[Random.Range(0,effectList.effects.Count())];
        
        
        //send to GSM
        return potion;
    }



}
public class Potion
{
    //name is concat,  "Elixir(sweet medicine), Draught(beer), Tincture(extract in alcohol), Brew(evil), Mixture(neutral)," + " of " + majorEffect
    public string name;
    public List<EffectObject> potionEffects;
}

