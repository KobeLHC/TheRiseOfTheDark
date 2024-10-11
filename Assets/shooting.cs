using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public float timeBetweenFiring;
    private float timer;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotz);

        //new part
        /*if(Mathf.Abs(rotz) > -30f && Mathf.Abs(rotz) < 120f)
        {
            bulletTransform.localScale = new Vector3(bulletTransform.localScale.x, Mathf.Abs(bulletTransform.localScale.y), bulletTransform.localScale.z);
        }
        else if (Mathf.Abs(rotz) > 120f && Mathf.Abs(rotz) < 160f )
        {
            bulletTransform.localScale = new Vector3(-Mathf.Abs(bulletTransform.localScale.x), -Mathf.Abs(bulletTransform.localScale.y), bulletTransform.localScale.z);
        }
        else
        {
            bulletTransform.localScale = new Vector3(bulletTransform.localScale.x, Mathf.Abs(bulletTransform.localScale.y), bulletTransform.localScale.z);
        }*/

        timer += Time.deltaTime;

        if (timer >= timeBetweenFiring)
        {
            attack();
            timer = 0;
        }

    }

    void attack()
    {
        Instantiate(bullet, bulletTransform.transform.position, bulletTransform.transform.rotation);
    }
}
