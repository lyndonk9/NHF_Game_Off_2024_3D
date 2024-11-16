using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Player_Interaction player;
    public GameObject bluePotion;
    public GameObject redPotion;
    public Dictionary<string, GameObject> potionDict = new Dictionary<string, GameObject>();

    public void Start()
    {
        potionDict.Add("redpotion", redPotion);
        potionDict.Add("bluepotion", bluePotion);
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
