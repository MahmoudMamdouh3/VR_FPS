using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int scoreValue = 10; 
    public int scoreMultiplier = 1; // Default is 1
    
    public AudioClip explosionSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Calculate the final score!
            int finalScore = scoreValue * scoreMultiplier;
            FindObjectOfType<ScoreManager>().AddScore(finalScore);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}