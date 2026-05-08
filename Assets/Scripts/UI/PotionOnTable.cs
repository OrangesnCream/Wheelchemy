using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PotionOnTable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionName;
    // Start is called before the first frame update
    void Start()
    {
         potionName.text=GameData.newPotion.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
