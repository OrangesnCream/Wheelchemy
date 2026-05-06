using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    // Start is called before the first frame update
    private List<(string name,int potency)> ingredientList=new List<(string name, int potency)>();
    void Start()
    {

        AddIngredient("Blue",3);
        Debug.Log("Name "+ingredientList[0].name);
        Debug.Log("potency "+ingredientList[0].potency);
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
}

