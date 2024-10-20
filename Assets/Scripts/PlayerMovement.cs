using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player movement control
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    private Vector2 lastMovementDirection;


    void Start()
    {
        
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //Update Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

}
