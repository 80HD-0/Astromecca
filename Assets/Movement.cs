using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.AccessControl;
using System.Threading;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float sensetivity = 1;
    public Rigidbody playerRB;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 moveDirection = player.forward * verticalAxis + player.right * horizontalAxis;
        playerRB.velocity = new Vector3(horizontalAxis*movementSpeed, playerRB.velocity.y, verticalAxis*movementSpeed);
        float mouseX = Input.GetAxis("Mouse X");
        player.Rotate(Vector3.up * (mouseX * sensetivity));
    }
}
