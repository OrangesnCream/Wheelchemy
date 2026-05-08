using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtonSelection : MonoBehaviour
{
    public ItemSelection selectManager;
    public string itemName;
    private Transform backObject;
    private Transform mainImage;
    public Sprite itemSprite;
    [SerializeField] private TextMeshProUGUI output;
    // Start is called before the first frame update
    void Start()
    {
        backObject=transform.Find("Background");
        mainImage=transform.Find("Image");
        output.text=itemName;
        mainImage.gameObject.GetComponent<Image>().sprite=itemSprite;
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
