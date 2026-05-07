using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TheWheel wheel;
    public Cauldron thePot;

    private List<(string name,int potency)> tempList=new List<(string name, int potency)>
    {
        ("Dragon Kale",1),
        ("Face Turnip",1),
        ("Eye Plant",1),
        ("Pig Ginger",1)
    };//used for testing, this should be sent to the wheel
    void Start()
    {
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
        wheel.GetComponentInChildren<IngredientIcons>().SetImages();
        for(int i = 0; i < 4; i++)
        {
            thePot.AddIngredient(tempList[i].name,wheel.returnedArray[i]);
        }
        thePot.testPrint();


    }
    public string GetActiveIngredient(int index)
    {
        if (index > 4)
        {
            Debug.Log("index too large");
            return null;
        }

        return tempList[index].name;
    }
}
