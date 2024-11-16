using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player_Interaction : MonoBehaviour
{
    //text prompt object
    [SerializeField] GameObject textPrompt;

    [SerializeField] private Inventory inventory;

    [SerializeField] private float moveSpeed = 6;


    private Rigidbody rigidBody;

    private GameObject potionCrate;

    private GameObject cauldron;

    private Vector2 moveInput;

    private String potionKey = "";

    private bool isCollidingCauldron;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    //determines whether or not the player is within the range of the potion crate
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("potioncrate"))
        {
            potionCrate = collider.gameObject;
            textPrompt.GetComponent<TMP_Text>().text = "Press E to pickup potion";
        }
        else if (collider.gameObject.CompareTag("cauldron"))
        {
            cauldron = collider.gameObject;
            textPrompt.GetComponent<TMP_Text>().text = "Press E to add potion\nPress F to mix";
        }
    }

    //triggers when player exit potion crate range
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("potioncrate"))
        {
            potionCrate = null;
            textPrompt.GetComponent<TMP_Text>().text = "";
        }
        else if (collider.gameObject.CompareTag("cauldron"))
        {
            cauldron = null;
            textPrompt.GetComponent<TMP_Text>().text = "";
        }
    }

    public void FixedUpdate ()
    {
        rigidBody.linearVelocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnInteract(InputValue value)
    {
        if (potionCrate && potionKey.Length == 0)
        {
            potionKey = potionCrate.gameObject.GetComponent<Potion_Crate>().potionKey;
            inventory.ShowItem(potionKey);
        } 
        else if (cauldron && potionKey.Length > 0)
        {
            cauldron.GetComponent<Cauldron>().AddItem(potionKey);
            inventory.HideItem(potionKey);
            potionKey = "";
        }
    }

    public void OnMix(InputValue value)
    {
        if (cauldron)
        {
            cauldron.GetComponent<Cauldron>().MixPotion();
        }
    }
}

