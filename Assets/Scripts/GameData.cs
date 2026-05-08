using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int money=0;
    public static Customer activeCustomer;
    public static int gameProg=0;
    public static Potion newPotion;
    public static int customerResponse;//0 happy, 1 sad, 2 angry
    public static List<(string name,int potency)> itemMenuSelections=new List<(string name, int potency)>();

}
