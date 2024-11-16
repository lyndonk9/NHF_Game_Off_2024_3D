using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_interaction : MonoBehaviour
{
    //text prompt object
    [SerializeField] GameObject textPrompt;

    //string to represent which potion color crate the player is in range of
    public int potioncolorCode;

    public GameObject heldItem;

    [SerializeField] private inventory inventoryScript;

    [SerializeField] private float moveSpeed = 6;


    private Rigidbody rigidBody;

    private Collider potionCrateCollider;

    private Vector2 moveInput;

    private String potionKey = "";

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    //determines whether or not the player is within the range of the potion crate
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("potioncrate"))
        {
            potionCrateCollider = collider;
            textPrompt.SetActive(true);
        }
    }

    //triggers when player exit potion crate range
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("potioncrate"))
        {
            potionCrateCollider = null;
            textPrompt.SetActive(false);
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
        if (potionCrateCollider && potionKey.Length == 0)
        {
            potionKey = potionCrateCollider.gameObject.GetComponent<Potion_Crate>().potionKey;
            inventoryScript.ShowItem(potionKey);
        }
    }
}

