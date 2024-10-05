using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public GameObject player;

    //int randomSpawnPoint;
    //int randomEnemy;
    Vector3 randomSpawn;
    int offset;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        offset = Random.Range(-10, 20);
        randomSpawn = new Vector3((player.transform.position.x + offset), (player.transform.position.y + offset), 0);
        spawnPoints[0].position = randomSpawn;
        Instantiate(enemies[0], spawnPoints[0].position, Quaternion.identity);
    }
}
