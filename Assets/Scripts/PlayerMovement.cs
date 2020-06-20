using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody playerRB;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Vector2 upperBounds;
    private Vector2 lowerBounds;

    public Shooter gun;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        upperBounds = new Vector2(8f, 5f);
        lowerBounds = new Vector2(-8f, -4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic function to read user input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        moveVelocity = moveInput * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.isFiring = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gun.isFiring = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 playerPos = playerRB.position;
        playerRB.velocity = moveVelocity;
        if(playerPos.x <= lowerBounds.x)
            playerRB.position = new Vector3(lowerBounds.x, playerPos.y, playerPos.z);
        if (playerPos.x >= upperBounds.x)
            playerRB.position = new Vector3(upperBounds.x, playerPos.y, playerPos.z);
        if (playerPos.y <= lowerBounds.y)
            playerRB.position = new Vector3(playerPos.x, lowerBounds.y, playerPos.z);
        if (playerPos.y >= upperBounds.y)
            playerRB.position = new Vector3(playerPos.x, upperBounds.y, playerPos.z);
    }
}
