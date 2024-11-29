using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Follow Player
    Rigidbody2D rb;
    GameObject target;
    public float moveSpeed;
    Vector3 directionToTarget;

    //Taking Fire Damage
    public int enemyHealth = 5;
    [SerializeField] private spellControl fire;
    //Taking Water Damage
    [SerializeField] private spellControl water;
    //Taking Grass Damage
    [SerializeField] private spellControl grass;

    //Enemy Animate
    private Animator anim;

    //Control Soul Bar
    private UIFill soulControl;

    //XP Bar control
    private playerXP playerXP;

    //Arrow Enemy
    public GameObject arrow;
    public Transform arrowPos;
    private float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        arrowPos = GetComponent<Transform>();
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

        //Initialize fire property
        if (fire == null)
        {
            GameObject fireObject = GameObject.Find("Fire Spell LV1");
            if (fireObject != null)
            {
                fire = fireObject.GetComponent<spellControl>();
            }
        }

        //Initialize water property
        if (water == null)
        {
            GameObject waterObject = GameObject.Find("Water Spell LV1");
            if (waterObject != null)
            {
                water = waterObject.GetComponent<spellControl>();
            }
        }

        //Initialize grass property
        if (grass == null)
        {
            GameObject grassObject = GameObject.Find("Grass Spell LV1");
            if (grassObject != null)
            {
                grass = grassObject.GetComponent<spellControl>();
            }
        }

    }

    void Update()
    {
        moveEnemy();
        timer += Time.deltaTime;

        if(timer > 2 && gameObject.tag == "Enemy2")
        {
            timer = 0;
            shootArrow();
        }

    }

    void moveEnemy()
    {
        if(target != null)
        {
            //move towards player automatically
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
            
            if(directionToTarget.x > 0)
            {
                //rb.rotation = 0;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (directionToTarget.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

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
        //Taking Fire Damage
        if(collision.gameObject.tag == "Fire")
        {
            takePlayerDamage((fire.damage + spellControl.getUp()));

            if (enemyHealth <= 0)
            {
                //test
                soulControl.add(10);
                playerXP.addXP(1);
                Destroy(gameObject);
            }
        }

        //Taking Water Damage
        if (collision.gameObject.tag == "Water")
        {
            takePlayerDamage((water.damage + spellControl.getUp()));
            moveSpeed -= 1;

            if(moveSpeed == 0)
            {
                moveSpeed = 1;
            }

            if(enemyHealth <= 0)
            {
                //test
                soulControl.add(10);
                playerXP.addXP(1);
                Destroy(gameObject);
            }
        }

        //Taking Grass Block
        if (collision.gameObject.tag == "Grass")
        {
            //takePlayerDamage((grass.damage + spellControl.getUp()));

            if (enemyHealth <= 0)
            {
                //test
                soulControl.add(10);
                playerXP.addXP(1);
                Destroy(gameObject);
            }
        }

        //Short Range Attack Player
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Enemy")
        {
            anim.SetTrigger("attack");
        }

    }

    //Contiune Short Range Attack Player
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Enemy")
        {
            anim.SetTrigger("attack");
        }
    }

    private void animDamage()
    {
        soulControl.deduct(5);
    }

    private void shootArrow()
    {
        Instantiate(arrow, arrowPos.position, Quaternion.identity);
    }
}
