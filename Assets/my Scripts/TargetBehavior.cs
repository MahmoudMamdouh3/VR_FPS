using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int scoreValue = 10; 

    // Changed from OnCollisionEnter to OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        // Unity adds "(Clone)" to the end of spawned bullets, so we use .Contains
        if (other.gameObject.name.Contains("Bullet"))
        {
            // 1. Destroy the bullet
            Destroy(other.gameObject);
            
            // 2. Destroy this target box
            Destroy(gameObject);
        }
    }
}