using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    public float movevSpeed;
    Vector3 directionToTarget;
    public int enemyHealth = 5;
    [SerializeField] private spellControl fire;

    //Control Soul Bar
    private UIFill soulAdd;

    //XP Bar control
    private playerXP playerXP;

    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        GameObject soulBarObject = GameObject.Find("Soul Bar");
        if (soulBarObject != null)
        {
            soulAdd = soulBarObject.GetComponent<UIFill>();
        }


        GameObject playerXPObject = GameObject.Find("XPBar");
        if (playerXPObject != null)
        {
            playerXP = playerXPObject.GetComponent<playerXP>();
        }

        if (fire == null)
        {
            GameObject fireObject = GameObject.Find("Fire Spell LV1");
            if (fireObject != null)
            {
                fire = fireObject.GetComponent<spellControl>();
            }
        }

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
            takePlayerDamage(fire.damage);
            if (enemyHealth <= 0)
            {
                soulAdd.add(10);
                playerXP.addXP(1);
                Destroy(gameObject);
            }
        }
    }
}
