using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    public void Shoot()
    {
        // 1. Create the bullet at the firepoint's exact position and rotation
        GameObject spawnedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // 2. Add speed to the bullet to make it fly forward
        spawnedBullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
        
        // 3. Destroy the bullet after 3 seconds so it doesn't crash the game later
        Destroy(spawnedBullet, 3f);
    }
}