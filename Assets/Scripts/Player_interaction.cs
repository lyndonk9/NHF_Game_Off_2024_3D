using System;
using UnityEngine;

public class Player_interaction : MonoBehaviour
{
    //text prompt object
    [SerializeField] GameObject textPrompt;
    
    //bool to determine whether or not player is in range of potion crate
    public bool inRange;

    //array to represent inventory items
    public int[] inventory = new int[1];

    //string to represent which potion color crate the player is in range of
    public int potioncolorCode;

    public void Start()
    {
        //instatiate inventory so it is empty (0,0)
        inventory[0] = 0;

        Debug.Log(inventory);
    }
    
    //determines whether or not the player is within the range of the potion crate
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("textprompttrigger"))
        {
            textPrompt.SetActive(true);
            inRange = true;

        }

        if (collision.gameObject.CompareTag("redpotiontrigger"))
        {
            potioncolorCode = 2;

        }

        if (collision.gameObject.CompareTag("bluepotiontrigger"))
        {
            potioncolorCode = 3;

        }
    }


    //triggers when player exit potion crate range
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("textprompttrigger"))
        {
            textPrompt.SetActive(false);
            inRange = false;
            potioncolorCode = 0;
        }
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (inventory[0] != 0)
            {
                Debug.Log("inventory is full!");
            }

            if (inRange)
            {

                if (inventory[0] == 0)
                {
                    inventory[0] = potioncolorCode;
                    Debug.Log("you picked up a potion! color code: " + potioncolorCode);
                }

            }

        }

                
        }
    }

        


