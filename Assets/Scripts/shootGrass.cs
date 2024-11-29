using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shootGrass : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public float timeBetweenFiring;
    private float timer;
    public Transform playerPivot;

    public GameObject grass;
    public levelUpMenu unlockKey;
    private bool grassOn;

    void Start()
    {
        GameObject unlockKeyObject = GameObject.Find("Level Up Menu");
        if (unlockKeyObject != null)
        {
            unlockKey = unlockKeyObject.GetComponent<levelUpMenu>();
        }

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        grassOn = false;

    }

    void Update()
    {
        //Grass attack pattern
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

        if (Mathf.Abs(rotz) > 0f && Mathf.Abs(rotz) < 50f)
        {
            playerPivot.localScale = new Vector3(playerPivot.localScale.x, Mathf.Abs(playerPivot.localScale.y), playerPivot.localScale.z);
        }
        else if (Mathf.Abs(rotz) > 120f && Mathf.Abs(rotz) < 150f)
        {
            playerPivot.localScale = new Vector3(-Mathf.Abs(playerPivot.localScale.x), -Mathf.Abs(playerPivot.localScale.y), playerPivot.localScale.z);
        }

        timer += Time.deltaTime;

       

        if (unlockKey.sentUnlockG() == true)
        {
            grassOn = true;
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            grassOn = false;
        }*/

        if (/*timer >= timeBetweenFiring*/ Input.GetKeyDown(KeyCode.Space))
        {
            attack();
            //timer = 0;
        }

    }

    void attack()
    {
        //grass attack
         if(grassOn == true)
        {
            Instantiate(grass, playerPivot.position, playerPivot.rotation);
        }

    }
}
