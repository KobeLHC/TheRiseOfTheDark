using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    public float movevSpeed;
    Vector3 directionToTarget;

    public int enemyHealth = 5;

    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        moveEnemy();
    }

    void moveEnemy()
    {
        if(target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * movevSpeed, directionToTarget.y * movevSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void takePlayerDamage(int dmg)
    {
        enemyHealth -= dmg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            takePlayerDamage(1);
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
