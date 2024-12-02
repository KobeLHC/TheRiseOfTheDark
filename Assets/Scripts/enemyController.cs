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

    //Boss HP bar control
    public bossHP hp;

    //Arrow Enemy
    public GameObject arrow;
    public Transform arrowPos;
    private float timer;

    //Audio
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
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
        if(timer > 1 && gameObject.tag == "Enemy2")
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
        if(gameObject.tag == "Enemy" || gameObject.tag == "Enemy2")
        {
            enemyHealth -= dmg;
            Debug.Log("Enemy taking " + dmg);
        }

        else if(gameObject.tag == "Boss")
        {
            hp.minusHP(dmg);
            enemyHealth -= dmg;
            Debug.Log("Enemy taking " + dmg);

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Taking Fire Damage
        if(collision.gameObject.tag == "Fire")
        {
            takePlayerDamage((fire.damage + spellControl.getUpFire()));
            audioManager.playSFX(audioManager.fireHit);
            if (enemyHealth <= 0)
            {
                audioManager.playSFX(audioManager.eDeath);
                soulControl.add(3);
                playerXP.addXP(2);
                Destroy(gameObject);
            }
        }

        //Taking Water Damage
        if (collision.gameObject.tag == "Water")
        {
            takePlayerDamage((water.damage + spellControl.getUpWater()));
            audioManager.playSFX(audioManager.waterHit);
            moveSpeed -= 1;

            if(moveSpeed <= 2)
            {
                moveSpeed = 2;
            }

            if(enemyHealth <= 0)
            {
                audioManager.playSFX(audioManager.eDeath);
                soulControl.add(3);
                playerXP.addXP(2);
                Destroy(gameObject);
            }
        }

        //Taking Grass Block
        if (collision.gameObject.tag == "Grass")
        {
            audioManager.playSFX(audioManager.grassHit);

            if (gameObject.CompareTag("Boss"))
            {
                Collider2D enemyCollider = collision.collider;
                Collider2D thisCollider = GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(thisCollider, enemyCollider);
            }
        }

        //Short Range Attack Player
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Enemy" || collision.gameObject.CompareTag("Player") && gameObject.tag == "Boss")
        {
            anim.SetTrigger("attack");
        }

    }

    //Contiune Short Range Attack Player
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Enemy" || collision.gameObject.CompareTag("Player") && gameObject.tag == "Boss")
        {
            anim.SetTrigger("attack");
        }
    }

    private void animForkDamage()
    {
        audioManager.playSFX(audioManager.eShortAttack);
        soulControl.deduct(2);
    }

    private void animKnightDamage()
    {
        audioManager.playSFX(audioManager.eShortAttack);
        soulControl.deduct(4);  
    }

    private void animBossDamage()
    {
        audioManager.playSFX(audioManager.bossAttack);
        soulControl.deduct(10);
    }

    private void shootArrow()
    {
        Instantiate(arrow, arrowPos.position, Quaternion.identity);
    }
}
