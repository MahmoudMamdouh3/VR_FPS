using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int scoreValue = 10; 

    // Changed from OnCollisionEnter to OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            // Find the ScoreManager in the scene and send it the points!
            FindObjectOfType<ScoreManager>().AddScore(scoreValue);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}