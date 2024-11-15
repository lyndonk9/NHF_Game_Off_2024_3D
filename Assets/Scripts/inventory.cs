using UnityEngine;

public class inventory : MonoBehaviour
{
    public Player_interaction player;
    public GameObject bluePotion;
    public GameObject redPotion;

    // Update is called once per frame
    void Update()
    {

        if (player.inventory[0] == 3)
        {
            bluePotion.SetActive(true);
        }

        if (player.inventory[0] == 2)
        {
            redPotion.SetActive(true);
        }

        if (player.inventory[0] == 0)
        {
            bluePotion.SetActive(false); redPotion.SetActive(false);
        }

    }
}
