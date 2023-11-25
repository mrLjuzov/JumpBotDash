using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Store your obstacle prefabs here
    public Transform spawnPoint;
    public float minSpawnDelay = 3.0f;
    public float maxSpawnDelay = 3.0f;

    private bool isSpawning = false;
    private bool isFirstObstacle = true;

    private void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (!isSpawning)
            {
                isSpawning = true;

                if (isFirstObstacle)
                {
                    // Spawn the first obstacle immediately (excluding "Rocket 2")
                    SpawnFirstObstacle();
                    isFirstObstacle = false;
                }
                else
                {
                    // Wait for a random delay within the specified range
                    float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
                    yield return new WaitForSeconds(delay);

                    // Spawn the next obstacle
                    SpawnObstacle();
                }

                isSpawning = false;
            }
            yield return null;
        }
    }

    private void SpawnFirstObstacle()
    {
        GameObject randomObstaclePrefab;

        // Keep reselecting until a non-"Rocket 2" obstacle is chosen
        do
        {
            randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        } while (randomObstaclePrefab.CompareTag("Rocket2"));

        // Get the position of the random obstacle prefab
        Vector3 spawnPosition = randomObstaclePrefab.transform.position;

        // Debug log to check which obstacle is spawned and its position
        Debug.Log("Spawning " + randomObstaclePrefab.name + " at position: " + spawnPosition);

        // Instantiate the obstacle at the original prefab's position
        GameObject spawnedObstacle = Instantiate(randomObstaclePrefab, spawnPosition, Quaternion.identity);

        // Ensure that the spawned obstacle has one of the specified tags
        if (spawnedObstacle.CompareTag("Spike1") || spawnedObstacle.CompareTag("Spike2") || spawnedObstacle.CompareTag("Rocket1") || spawnedObstacle.CompareTag("Rocket2"))
        {
            // Optionally, you can add more customization for the spawned obstacle here
        }
    }

    private void SpawnObstacle()
    {
        // Spawn a random obstacle from the array
        GameObject randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Get the position of the random obstacle prefab
        Vector3 spawnPosition = randomObstaclePrefab.transform.position;

        // Debug log to check which obstacle is spawned and its position
        Debug.Log("Spawning " + randomObstaclePrefab.name + " at position: " + spawnPosition);

        // Instantiate the obstacle at the original prefab's position
        GameObject spawnedObstacle = Instantiate(randomObstaclePrefab, spawnPosition, Quaternion.identity);

        // Ensure that the spawned obstacle has one of the specified tags
        if (spawnedObstacle.CompareTag("Spike1") || spawnedObstacle.CompareTag("Spike2") || spawnedObstacle.CompareTag("Rocket1") || spawnedObstacle.CompareTag("Rocket2"))
        {
            // Optionally, you can add more customization for the spawned obstacle here
        }
    }
}



