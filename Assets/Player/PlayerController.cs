using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 12f;
    public float currentSpeed;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isSprinting = false;

    Vector3 velocity;
    bool isGrounded;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed; // Initialize speed
    }   

    void Update()
    {
        // Check if player is touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            // Reset velocity, keeping a tiny downward force to stay stuck to slopes
            velocity.y = -2f;
        }

        // Get keyboard input (WASD / Arrow keys)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate direction relative to the direction the player is looking
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the player
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Handle Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Physics formula for calculating required velocity to reach a specific height
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Sprint"))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        // Handle Sprint
        if (isSprinting == true)
        {
            currentSpeed = sprintSpeed;
        }
        if (isSprinting == false)
        {
            currentSpeed = walkSpeed;
        }   

        // Apply gravity over time
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement (gravity/jumping)
        controller.Move(velocity * Time.deltaTime);
    }
}