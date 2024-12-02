using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public GameObject player;

    audioManager audioManager;

    //int randomSpawnPoint;
    int randomEnemy;
    Vector3 randomSpawn;
    int offset;

    //Spawn Boss
    public Timer soulCheck;
    public GameObject boss;

    [SerializeField] private float spawnRate = 3f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    void Start()
    {
        /*if (soulCheck == null)
        {
            GameObject soulObject = GameObject.Find("Canvas");
            if (soulObject != null)
            {
                soulCheck = soulObject.GetComponent<Timer>();
            }
        }*/


        StartCoroutine(spawnEnemy());
    }

    void Update()
    {
       
    }

    private IEnumerator spawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return wait;
            offset = Random.Range(-10, 20);
            randomSpawn = new Vector3((player.transform.position.x + offset), (player.transform.position.y + offset), 0);
            randomEnemy = Random.Range(0, 3);
            spawnPoints[0].position = randomSpawn;

            if (spawnPoints[0].position.y <= 13 && spawnPoints[0].position.y >= -13 && spawnPoints[0].position.x >= -20 && spawnPoints[0].position.x <= 20)
            {
                Instantiate(enemies[randomEnemy], spawnPoints[0].position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[randomEnemy], spawnPoints[2].position, Quaternion.identity);
            }
        }
    }

    public void spawn()
    {
        audioManager.playMusic(audioManager.backgroundBoss);
        Instantiate(boss, spawnPoints[1].position, Quaternion.identity);
       
    }

    
}
