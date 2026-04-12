using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    
    // How often a new target appears (in seconds)
    public float spawnRate = 2f; 

    // The invisible box area where targets are allowed to spawn
    public Vector3 spawnAreaSize = new Vector3(10f, 4f, 5f);
    public Transform spawnCenter;

    void Start()
    {
        // Starts a repeating timer that calls the SpawnTarget function
        InvokeRepeating("SpawnTarget", 2f, spawnRate);
    }

    void SpawnTarget()
    {
        // Generate random X, Y, and Z coordinates within our defined area
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomY = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
        float randomZ = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

        Vector3 randomPosition = spawnCenter.position + new Vector3(randomX, randomY, randomZ);

        // Create the target at that random position
        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}