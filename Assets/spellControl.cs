using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class spellControl : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed, baseOffset;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;

    public int damage;


    void Start()
    {
        damage = 1;
        transform.Translate(Vector3.right * baseOffset);
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
         mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        InvokeRepeating("destroy", 5f, 4f);
    }
    private void Update()
    {
       
    }

    public void damageAdd(int dmg)
    {
        damage += dmg;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Wall") )
        {
            gameObject.SetActive(false);
        }
    }


    private void destroy()
    {
        gameObject.SetActive(false);  
    }
}
