using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellControl : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
     

    void Start()
    {
        Invoke("Destroy", 2f);
    }
    void Update()
    {
     transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            other.gameObject.SetActive(false);
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);  
    }
}
