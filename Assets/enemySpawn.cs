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

    [SerializeField] private float spawnRate = 3f;

    void Start()
    {
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
            spawnPoints[0].position = randomSpawn;
            if (spawnPoints[0].position.y <= 13 && spawnPoints[0].position.y >= -13 && spawnPoints[0].position.x >= -23 && spawnPoints[0].position.x <= 23)
            {
                Instantiate(enemies[0], spawnPoints[0].position, Quaternion.identity);
            }
        }
    }
}
