using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    //Spell Direction
    private PlayerMovement playerMovement;
    [SerializeField] private float offsetDistance = 1f;

    //Spell Pool
    public static playerAttack instance;
    public GameObject prefab;
    public List<GameObject> pooledObject;
    public int countToPool = 20;
    public bool canExpand = false;

    //Spell Pattern Control
    [SerializeField] private int spellAmount = 10;
    //[SerializeField] private float startAngle = 90f, endAngle = 270f;
   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        pooledObject = new List<GameObject>();
        for (int i = 0; i < countToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        InvokeRepeating("fire", 0f, 2f);
    }

    void Update()
    {

    }

    void fire()
    {
        Vector2 playerFacingDirection = playerMovement.GetFacingDirection();

        /*float baseAngle = Mathf.Atan2(playerFacingDirection.y, playerFacingDirection.x) * Mathf.Rad2Deg;

        float angleStep = (endAngle - startAngle) / spellAmount;
        float angle = startAngle;*/

        float angleStep = 360f / spellAmount;
        float angle = 0f;

        for (int i = 0; i < spellAmount; i++)
        {
            /*float adjustedAngle = baseAngle + angle;

            float speDirX = Mathf.Cos(adjustedAngle * Mathf.PI / 180f);
            float speDirY = Mathf.Sin(adjustedAngle * Mathf.PI / 180f);*/

            float speDirX = Mathf.Cos(angle * Mathf.PI / 180f);
            float speDirY = Mathf.Sin(angle * Mathf.PI / 180f);

            Vector2 spellDirection = new Vector2(speDirX, speDirY).normalized;

            GameObject newSpell = instance.GetPooledObject();
            if (newSpell == null)
            {
                return;
            }

            //newSpell.transform.position = transform.position;
            //newSpell.transform.rotation = Quaternion.Euler(0, 0, adjustedAngle);

            Vector2 spellStartPosition = (Vector2)transform.position + spellDirection * offsetDistance;

            newSpell.transform.position = spellStartPosition;  
            newSpell.transform.rotation = Quaternion.Euler(0, 0, angle);

            newSpell.SetActive(true);
            newSpell.GetComponent<spellControl>().SetMoveDirection(spellDirection);

            angle += angleStep;
        }
    }


    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        if (canExpand)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObject.Add(obj);
            return obj;
        }
        return null;
    }

}
