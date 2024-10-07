using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player movement control
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    Vector2 moveAmount;
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        //Get directions
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        /*movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = movement.normalized * moveSpeed;

        switch(movement)
        {
            case Vector2 vector when vector.Equals(Vector2.right) :
                player.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
            case Vector2 vector when vector.Equals(Vector2.left):
                player.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case Vector2 vector when vector.Equals(Vector2.up):
                player.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case Vector2 vector when vector.Equals(Vector2.down):
                player.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
                break;
            default:
                break;
        }
        */

    }

    void FixedUpdate()
    {
        //Update Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

   }
