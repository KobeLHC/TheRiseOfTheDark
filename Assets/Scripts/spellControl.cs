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
    //static public int up;

    static public int upFire;
    static public int upWater;


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

        

       /*float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(0, 0, rot);*/

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
        /*if(soulCheck.getFullSoul() == true)
        {
            Debug.Log("Added 10");
            damageAdd(10);
            soulCheck.setFullSoul(false);
        }*/
        
    }

    public static void allMax()
    {
        upFire = 10;
        upWater = 5;
    }

    public static void damageAddFire(int dmg)
    {
        upFire += dmg;
        Debug.Log(" Upfire: " + upFire);
    }

    public static void damageAddWater(int dmg)
    {
        upWater += dmg;
        Debug.Log(" New Damage: " + upWater);
    }



    public static int getUpFire()
    {
        int powerUpValue = upFire;
        //Debug.Log("Getting up value is " +  powerUpValue);
        return powerUpValue;
    }

    public static int getUpWater()
    {
        int powerUpValue = upWater;
        //Debug.Log("Getting up value is " +  powerUpValue);
        return powerUpValue;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Grass")
        {
            //gameObject.SetActive(false);
        }

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
