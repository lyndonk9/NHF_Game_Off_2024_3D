using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Player_Interaction player;
    public GameObject redPotion;
    public GameObject yellowPotion;
    public GameObject greenPotion;
    public GameObject bluePotion;
    public GameObject purplePotion;
    public Dictionary<string, GameObject> potionDict = new Dictionary<string, GameObject>();

    public void Start()
    {
        potionDict.Add("1", redPotion);
        potionDict.Add("2", yellowPotion);
        potionDict.Add("3", greenPotion);
        potionDict.Add("4", bluePotion);
        potionDict.Add("5", purplePotion);
    }

    public void ShowItem(string potionKey)
    {
        potionDict[potionKey].SetActive(true);
    }

    public void HideItem(string potionKey)
    {
        potionDict[potionKey].SetActive(false);
    }
}
