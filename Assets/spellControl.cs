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

    void Start()
    {

        transform.Translate(Vector3.right * baseOffset);
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //Destroy bullet after 4 sec
        InvokeRepeating("destroy", 5f, 4f);
    }
    private void Update()
    {
        
    }


    public static void damageAdd(int dmg)
    {
        up += dmg;
        Debug.Log("New up is " + up);
    }

    public static int getUp()
    {
        int powerUpValue = up;
        Debug.Log("Getting up value is " +  powerUpValue);
        return powerUpValue;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }


    private void destroy()
    {
        gameObject.SetActive(false);  
    }
}
