using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Follow Player
    Rigidbody2D rb;
    GameObject target;
    public float movevSpeed;
    Vector3 directionToTarget;

    //Taking Fire Damage
    public int enemyHealth = 5;
    [SerializeField] private spellControl fire;

    //Enemy Animate
    private Animator anim;

    //Control Soul Bar
    private UIFill soulControl;

    //XP Bar control
    private playerXP playerXP;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        GameObject soulBarObject = GameObject.Find("Soul Bar");
        if (soulBarObject != null)
        {
            soulControl = soulBarObject.GetComponent<UIFill>();
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
            //move towards player automatically
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
        Debug.Log("Enemy taking " + dmg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            takePlayerDamage((fire.damage + spellControl.getUp()));

            if (enemyHealth <= 0)
            {
                soulControl.add(5);
                playerXP.addXP(1);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("attack");
        }

    }

    private void animDamage()
    {
        soulControl.deduct(5);
    }
}
