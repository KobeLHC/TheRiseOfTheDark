using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public Transform bulletTransform;
    public float timeBetweenFiring;
    private float timer;
   // public Transform playerPivot;
    //public float rotationSpeed = 5.0f;

    public GameObject bullet;
    public GameObject water;
   // public GameObject grass;

    public levelUpMenu unlockKey;


    private bool fireOn;
    private bool waterOn;
    //private bool grassOn;
    
    //Audio
    audioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    void Start()
    {
        GameObject unlockKeyObject = GameObject.Find("Level Up Menu");
        if (unlockKeyObject != null)
        {
            unlockKey = unlockKeyObject.GetComponent<levelUpMenu>();
        }

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        fireOn = true;
        waterOn = false;
        //grassOn = false;

    }

    void Update()
    {
        //Fire & Water attack pattern following mouse
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

        /*//Grass attack pattern
        Vector3 pivotToObject = transform.position - playerPivot.position;
        transform.position = playerPivot.position + Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime) * pivotToObject;
        */

        if(rotation.z >= 0 && rotation.z <= 90 || rotation.z >= 270 && rotation.z <= 360)
        {
            bulletTransform.localScale = new Vector3(-Mathf.Abs(bulletTransform.localScale.x), -Mathf.Abs(bulletTransform.localScale.y), bulletTransform.localScale.z);
            
        }
        

        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && unlockKey.sentUnlockF() == true)
        {
            audioManager.playSFX(audioManager.switchSpell);
            fireOn = true;
            waterOn = false;
        }

        if (Input.GetMouseButtonDown(1) && unlockKey.sentUnlockW() == true)
        {
            audioManager.playSFX(audioManager.switchSpell);
            fireOn = false;
            waterOn = true;
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha3) && unlockKey.sentUnlockG() == true)
        {
            grassOn = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            grassOn = false;
        }*/

        if (timer >= timeBetweenFiring)
        {
            attack();
            timer = 0;
        }

    }

    void attack()
    {
        //fire attack
        if(fireOn == true && waterOn == false /*&& grassOn == false*/)
        {
            audioManager.playSFX(audioManager.pAttack);
            Instantiate(bullet, bulletTransform.transform.position, bulletTransform.transform.rotation);

        }

        //water attack
        else if(fireOn == false && waterOn == true /*&& grassOn == false*/)
        {
            audioManager.playSFX(audioManager.pAttack);
            Instantiate(water, bulletTransform.transform.position, bulletTransform.transform.rotation);
        }

        /*//grass & fire attack
        else if(fireOn == true && waterOn == false && grassOn == true)
        {
            Instantiate(bullet, bulletTransform.transform.position, bulletTransform.transform.rotation);
            Instantiate(grass, playerPivot.transform.position, playerPivot.transform.rotation);
        }
        //water & grass attack
        else if (fireOn == false && waterOn == true && grassOn == true)
        {
            Instantiate(water, bulletTransform.transform.position, bulletTransform.transform.rotation);
            Instantiate(grass, playerPivot.transform.position, playerPivot.transform.rotation);
        }*/
        
    }
}
