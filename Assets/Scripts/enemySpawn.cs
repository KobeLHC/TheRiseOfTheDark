using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public GameObject player;


    //int randomSpawnPoint;
    int randomEnemy;
    Vector3 randomSpawn;
    int offset;

    //Spawn Boss
    public Timer soulCheck;
    private bool bossSpawned;
    public GameObject boss;

    [SerializeField] private float spawnRate = 3f;

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

        bossSpawned = false;


        StartCoroutine(spawnEnemy());
    }

    void Update()
    {
      if (soulCheck.getRedMoonTimerEnd()  == true && bossSpawned == false)
        {
            spawn();
            bossSpawned = true;
        }
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

            if (spawnPoints[0].position.y <= 13 && spawnPoints[0].position.y >= -13 && spawnPoints[0].position.x >= -23 && spawnPoints[0].position.x <= 23)
            {
                Instantiate(enemies[randomEnemy], spawnPoints[0].position, Quaternion.identity);
            }
        }
    }

    private void spawn()
    {
        offset = Random.Range(-10, 20);
        randomSpawn = new Vector3((player.transform.position.x + offset), (player.transform.position.y + offset), 0);
        if (spawnPoints[0].position.y <= 13 && spawnPoints[0].position.y >= -13 && spawnPoints[0].position.x >= -23 && spawnPoints[0].position.x <= 23)
        {
            Instantiate(boss, spawnPoints[0].position, Quaternion.identity);
        }
    }
}
