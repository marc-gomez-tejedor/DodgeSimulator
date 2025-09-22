using UnityEngine;
using System.Collections.Generic;

public class EnemyPooling : MonoBehaviour
{
    public GameObject enemyPrefab;      // The enemy prefab to be spawned
    public GameObject[] floors;
    public int poolSize = 2;           // Total number of enemies in the pool
    public int spawnCount = 2;          // Number of enemies to spawn every interval
    public float spawnInterval = 3.0f;  // Time between each spawn

    private List<GameObject> enemies;   // List of all enemies in the pool
    private float timer = 0.0f;         // Timer to keep track of spawn intervals

    void insEnemy()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab);
        enemyInstance.SetActive(false);
        enemies.Add(enemyInstance);
    }
    void Start()
    {
        enemies = new List<GameObject>();

        // Create and initialize the pool
        for (int i = 0; i < poolSize; i++)
        {
            insEnemy();
        }

        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator<WaitForSeconds> SpawnEnemies()
    {
        while (true)
        {
            if (timer >= spawnInterval)
            {
                for (int i = 0, spawned = 0; i < poolSize && spawned < spawnCount; i++)
                {
                    if (!enemies[i].activeInHierarchy)
                    {
                        int roll = Random.Range(0, floors.Length);
                        GameObject floor = floors[roll];

                        // Fetch floor bounds
                        Bounds floorBounds = floor.GetComponent<Renderer>().bounds;
                        float floorXMin = floorBounds.min.x;
                        float floorXMax = floorBounds.max.x;
                        float floorZMin = floorBounds.min.z;
                        float floorZMax = floorBounds.max.z;

                        // Generate random position within floor bounds
                        float randX = Random.Range(floorXMin, floorXMax);
                        float randZ = Random.Range(floorZMin, floorZMax);
                        Vector3 spawnPosition = new Vector3(randX, floorBounds.min.y, randZ);

                        enemies[i].transform.position = spawnPosition;
                        enemies[i].SetActive(true);
                        spawned++;
                    }
                }

                timer = 0.0f;
                insEnemy();
                poolSize++;
            }

            yield return new WaitForSeconds(spawnInterval - timer);
        }
    }
}
