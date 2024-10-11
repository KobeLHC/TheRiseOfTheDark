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
