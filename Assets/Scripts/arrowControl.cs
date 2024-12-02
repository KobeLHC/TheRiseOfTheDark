using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;

    //Control Soul Bar
    private UIFill soulControl;

    //Audio
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject soulBarObject = GameObject.Find("Soul Bar");
        if (soulBarObject != null)
        {
            soulControl = soulBarObject.GetComponent<UIFill>();
        }

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        Vector3 rotation = transform.position - player.transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);


        InvokeRepeating("destroy", 5.0f, 5.0f);
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.playSFX(audioManager.eLongAttackHit);
            destroy();
            soulControl.deduct(6);
        }

        if (other.CompareTag("Grass"))
        {
            audioManager.playSFX(audioManager.eLongAttackHit);
            destroy();
        }
    }

    private void destroy()
    {
        gameObject.SetActive(false);
    }
}
