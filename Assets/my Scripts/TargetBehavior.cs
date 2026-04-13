using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public int scoreValue = 10; 
    public int scoreMultiplier = 1; // Default is 1
    
    public AudioClip explosionSound; 

    public GameObject floatingScorePrefab;
    
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
            
            // ==========================================
// SPAWN THE FLOATING SCORE TEXT
// ==========================================
            if (floatingScorePrefab != null)
            {
                // Spawn the text exactly where the target is
                GameObject popup = Instantiate(floatingScorePrefab, transform.position, Quaternion.identity);

                // Send the score number to the text
                popup.GetComponent<FloatingScore>().Setup(finalScore);
            }
// ==========================================
            
            

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}