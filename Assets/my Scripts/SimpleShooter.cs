using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro; // Needed for Ammo UI!

public class SimpleShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public AudioClip shootSound; 

    public int currentAmmo = 10;
    public int maxAmmo = 10;
    public XRSocketInteractor magSocket;
    
    // NEW: UI Slot for Ammo
    public TextMeshProUGUI ammoText; 

    void Start()
    {
        UpdateAmmoUI();
    }

    public void Shoot()
    {
        if (currentAmmo <= 0) return;

        currentAmmo--;
        UpdateAmmoUI();

        if (shootSound != null) AudioSource.PlayClipAtPoint(shootSound, firePoint.position);

        GameObject spawnedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(spawnedBullet, 3f);

        // Auto-Eject and Destroy Empty Mag
        if (currentAmmo == 0 && magSocket != null && magSocket.hasSelection)
        {
            // Grab the physical magazine object that is currently in the gun
            GameObject emptyMag = magSocket.firstInteractableSelected.transform.gameObject;
            
            magSocket.socketActive = false; 
            Invoke("ReenableSocket", 1.5f); 
            
            // Destroy the empty magazine 2 seconds after it drops to the floor
            Destroy(emptyMag, 2f);
        }
    }

    private void ReenableSocket()
    {
        magSocket.socketActive = true;
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        if (ammoText != null) ammoText.text = "AMMO: " + currentAmmo + " / " + maxAmmo;
    }
}