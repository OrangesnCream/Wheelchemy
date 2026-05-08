using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    public List<GameObject> gridButtons;
    public ItemInventory inventory;
    public GameObject prefab;

    public int selectionCount=0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ItemObject item in inventory.items)
        {
           GameObject child = Instantiate(prefab, gameObject.transform);
           child.GetComponent<ButtonSelection>().itemName=item.itemName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
