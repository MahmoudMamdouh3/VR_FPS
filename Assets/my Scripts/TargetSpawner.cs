using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targetPrefabs; 
    public float spawnRate = 2f; 
    public Vector3 spawnAreaSize = new Vector3(10f, 4f, 5f);
    public Transform spawnCenter;
    public int maxTargetsOnScreen = 6; 

    // NEW: This runs exactly when the script is turned ON by the Start Button
    void OnEnable()
    {
        InvokeRepeating("SpawnTarget", 2f, spawnRate);
    }

    // NEW: This runs exactly when the Menu turns the script OFF
    void OnDisable()
    {
        CancelInvoke("SpawnTarget");
    }

    void SpawnTarget()
    {
        TargetBehavior[] currentTargets = FindObjectsOfType<TargetBehavior>();
        
        if (currentTargets.Length >= maxTargetsOnScreen)
        {
            return; 
        }

        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomY = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
        float randomZ = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

        Vector3 randomPosition = spawnCenter.position + new Vector3(randomX, randomY, randomZ);
        
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        Instantiate(targetPrefabs[randomIndex], randomPosition, Quaternion.identity);
    }
}