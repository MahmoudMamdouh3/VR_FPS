using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    
    // NEW: Slot for your gunshot audio
    public AudioClip shootSound; 

    public void Shoot()
    {
        // NEW: Play the gunshot sound exactly where the barrel is
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, firePoint.position);
        }

        GameObject spawnedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(spawnedBullet, 3f);
    }
}