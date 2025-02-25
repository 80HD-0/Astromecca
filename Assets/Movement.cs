using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float sensetivity = 700.0f;  // Adjust as needed for smoothness
    public Rigidbody playerRB;
    public Transform player;
    public Collider grippers;
    private bool gripping;
    public float jumpStrength = 5;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to the center of the screen
        Cursor.visible = false; // Hides the cursor
    }

    // Update is called once per frame
    void Update()
    {
        // Get input axes for movement
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        // Handle player rotation
        HandleRotation();

        // Handle movement based on current rotation
        HandleMovement(verticalAxis, horizontalAxis);
        // Press Escape to unlock the cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // Unlocks the cursor so it can move freely
            Cursor.visible = true; // Shows the cursor
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked; // Locks cursor to the center of the screen
            Cursor.visible = false; // Hides the cursor
        }
        if (Input.GetAxis("Jump") == 1)
        {
            float startTime = Time.time;
            if (gripping) {
                playerRB.velocity = new Vector3(playerRB.velocity.x, jumpStrength, playerRB.velocity.z);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        gripping = true;
    }
    void OnTriggerExit(Collider other)
    {
        gripping = false;
    }

    void HandleRotation()
    {
        // Get mouse movement for rotation (mouseX controls yaw)
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the new rotation based on mouse input
        float turnAmount = mouseX * sensetivity * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y + turnAmount, player.eulerAngles.z);

        // Smoothly rotate the player
        player.rotation = Quaternion.RotateTowards(player.rotation, targetRotation, sensetivity * Time.deltaTime);
    }

    void HandleMovement(float vertical, float horizontal)
    {
        // Create movement vectors based on the player's local space (forward and right)
        Vector3 forward = player.transform.forward * vertical;
        Vector3 right = player.transform.right * horizontal;

        // Combine movement and apply to the Rigidbody, maintaining smoothness
        Vector3 movement = (forward + right).normalized * movementSpeed;

        // Apply the movement to the Rigidbody (keeping the y velocity for gravity)
        if (movement.x != 0 || movement.y != 0)
        {
            Vector3 newVelocity = new Vector3(movement.x, playerRB.velocity.y, movement.z);
            playerRB.velocity = newVelocity;
        }
    }
}
