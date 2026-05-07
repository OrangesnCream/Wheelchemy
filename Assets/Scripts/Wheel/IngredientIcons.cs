using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IngredientIcons : MonoBehaviour
{
    // Start is called before the first frame update
    TheWheel wheel;
    GameStateManager gameState;
    [SerializeField] private ItemInventory itemInv;

    public GameObject North;
    public GameObject South;
    public GameObject East;
    public GameObject West;
    int testInt=0;
    bool testBool=true;
    void Start()
    {
        wheel=GetComponentInParent<TheWheel>();
        gameState = FindObjectOfType<GameStateManager>();
        //SetImages();
    }
    // Update is called once per frame
    void Update()
    {
        if (testInt >500)
        {
            if(testBool)
                SetImages();
            testBool=false;
        }
        else
        {
            testInt++;
        }
    }

    //updates images next to the wheel 
    public void SetImages()
    {
        foreach (KeyValuePair<Vector3, int> kvp in wheel._valueMappings)
        {
            ItemObject ingredientObj=itemInv.GetByName(gameState.GetActiveIngredient(kvp.Value));
            switch ((int)kvp.Key.z)
            {
            
                case 0:
                    North.GetComponent<SpriteRenderer>().sprite=ingredientObj.icon;
                    
                    break;
                case 90:
                    West.GetComponent<SpriteRenderer>().sprite=ingredientObj.icon;
                     
                    break;
                case 180:
                    South.GetComponent<SpriteRenderer>().sprite=ingredientObj.icon;
                    
                    break;
                case 270:
                    East.GetComponent<SpriteRenderer>().sprite=ingredientObj.icon;
                    
                    break;
                default:
                    Debug.Log("Set Images rotation check broke");
                    break;
                
            }
        }
    }
    
}
