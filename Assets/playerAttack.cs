using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{


    //Spell Pool
    public static playerAttack instance;
    public GameObject prefab;
    public List<GameObject> pooledObject;
    public int countToPool = 20;
    public bool canExpand = false;

    //Spell Pattern Control
    [SerializeField] private int spellAmount = 10;
    [SerializeField] private float startAngle = 90f, endAngle = 270f;
   

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
        InvokeRepeating("fire", 0f, 2f);
    }

    void Update()
    {

    }

    void fire()
    {

        float angleStep = (endAngle - startAngle) / spellAmount;
        float angle = startAngle;

        for(int i = 0; i < spellAmount; i++)
        {
            float speDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float speDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 speMoveVector = new Vector3(speDirX, speDirY, 0f);
            Vector2 speDir = (speMoveVector - transform.position).normalized;

            GameObject newSpell = instance.GetPooledObject();
            if (newSpell == null)
            {
                return;
            }
            newSpell.transform.position = transform.position;
            newSpell.transform.rotation = transform.rotation;
            newSpell.SetActive(true);
            newSpell.GetComponent<spellControl>().SetMoveDirection(speDir);

            angle += angleStep;
        }
    }

    /*public Vector2 getDir()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }*/


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
