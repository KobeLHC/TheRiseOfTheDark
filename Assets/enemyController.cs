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

    //Attack player
    /*private float coolDownTimer = Mathf.Infinity;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    static int enemyDamage = 1;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    //test*/
    public GameObject enPrefab;





    //Control Soul Bar
    private UIFill soulControl;

    //XP Bar control
    private playerXP playerXP;

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
       // coolDownTimer += Time.deltaTime;
        moveEnemy();

        //Attack when player in range
        /*if (playerInSight())
        {
            if (coolDownTimer >= attackCoolDown)
            {
                coolDownTimer = 0;
                Instantiate(enPrefab);
            }
        }*/
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
                soulControl.add(10);
                playerXP.addXP(1);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            soulControl.deduct(5);
            Instantiate(enPrefab);
        }

    }

    /*private bool playerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }*/
}
