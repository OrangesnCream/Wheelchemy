using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSelection : MonoBehaviour
{
    public ItemSelection selectManager;
    public string itemName;
    private Transform backObject;
    [SerializeField] private TextMeshProUGUI output;
    // Start is called before the first frame update
    void Start()
    {
        backObject=transform.Find("Background");
        output.text=itemName;
        selectManager=gameObject.GetComponentInParent<ItemSelection>();
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleButton()
    {
        if (selectManager.gridButtons.Contains(gameObject))
        {
            selectManager.gridButtons.Remove(gameObject);
            selectManager.selectionCount--;
            backObject.gameObject.SetActive(!backObject.gameObject.activeSelf);
            return;
        }
        if (selectManager.selectionCount>3)
        {
            return;
        }

        selectManager.gridButtons.Add(gameObject);
        backObject.gameObject.SetActive(!backObject.gameObject.activeSelf);
        selectManager.selectionCount++;
        
    }
}
