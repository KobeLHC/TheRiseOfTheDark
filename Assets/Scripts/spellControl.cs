using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class spellControl : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed, baseOffset;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;

    public int damage = 1;
    static public int up;
    static private int showDmg = 2;

    public Timer soulCheck;

    public float destroyTime = 1.0f;

    void Start()
    {

        /*if (soulCheck == null)
        {
            GameObject soulObject = GameObject.Find("Canvas");
            Debug.Log("Print" + soulObject);
            if (soulObject != null)
            {
                soulCheck = soulObject.GetComponent<Timer>();
            }
        }*/

        transform.Translate(Vector3.right * baseOffset);
         rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;

       //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
       //transform.rotation = Quaternion.Euler(0, 0, rot);
       if(direction.z > 0)
        {
            rb.rotation = 180;
        }
        else
        {
            rb.rotation = 0;
        }

        //Destroy bullet after 4 sec
        InvokeRepeating("destroy", destroyTime, destroyTime);
       
    }
    private void Update()
    {
        if(soulCheck.getFullSoul() == true)
        {
            up = 10;
            soulCheck.setFullSoul(false);
        }
        else
        {
            //Debug.Log("soulCheck is false");
        }
        
    }


    public static void damageAdd(int dmg)
    {
        up += dmg;
        int value = up + showDmg;
        Debug.Log(" New Damage: " + value);
    }

    public static int getUp()
    {
        int powerUpValue = up;
        //Debug.Log("Getting up value is " +  powerUpValue);
        return powerUpValue;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Fire & Water atk, affective to all types enemy
        if (collision.gameObject.tag == "Enemy" && destroyTime == 3.0f || collision.gameObject.CompareTag("Wall") || collision.gameObject.tag == "Enemy2" && destroyTime == 3.0f || collision.gameObject.tag == "Boss" && destroyTime == 3.0f)
        {
            destroy();
        }

        //Grass Shield, only affective to normal enemy
        if (collision.gameObject.tag == "Enemy" && destroyTime == 1.0f || collision.gameObject.tag == "Enemy2" && destroyTime == 1.0f)
        {
            gameObject.SetActive(true);
        }
    }

    private void destroy()
    {
        gameObject.SetActive(false);  
    }
}
