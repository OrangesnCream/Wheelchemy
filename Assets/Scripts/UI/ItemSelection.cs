using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    public List<GameObject> gridButtons;//kkep this
    public ItemInventory inventory;
    public GameObject prefab;
    public Button nextButton;
    public int selectionCount=0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ItemObject item in inventory.items)
        {
           GameObject child = Instantiate(prefab, gameObject.transform);
           child.GetComponent<ButtonSelection>().itemName=item.itemName;
           child.GetComponent<ButtonSelection>().itemSprite=item.icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectionCount>3)
        {
            nextButton.interactable=true;
        }
        else
        {
            nextButton.interactable=false;
        }
    }
    public void PrepareForNextScreen()
    {
        GameData.itemMenuSelections.Clear();
        foreach(GameObject button in gridButtons){
            
            GameData.itemMenuSelections.Add((button.GetComponent<ButtonSelection>().itemName,1));

        }
    }
   
}
