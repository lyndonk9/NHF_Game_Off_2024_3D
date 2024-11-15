using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6;
    private Rigidbody rigidBody;
    private Vector2 moveInput;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }
}
