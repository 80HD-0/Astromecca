using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float sensitivity = 1.0f;
    public Rigidbody playerRB;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Get input axes
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the player based on mouse input (yaw rotation)
        float xRot = mouseX * sensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * xRot);

        // Move the player relative to the player's forward direction
        Vector3 forward = player.forward * verticalAxis;
        Vector3 right = player.right * horizontalAxis;
        Vector3 movement = (forward + right).normalized * movementSpeed;

        // Apply movement to the player's rigidbody
        playerRB.velocity = new Vector3(movement.x, playerRB.velocity.y, movement.z);
    }
}
