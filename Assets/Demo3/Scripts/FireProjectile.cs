using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float projectileSpeed = 100000f;

    // Re-factor this to new input system
    private void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    // This needs to be reworked.
    private void Fire()
    {
        // Create a new projectile from the prefab
        GameObject newProjectile = Instantiate(projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set the rotation explicitly
        newProjectile.transform.rotation = bulletSpawnPoint.rotation;

        // Get the rigidbody of the projectile
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();

        // Set the initial velocity of the projectile
        if (projectileRigidbody != null)
        {
            // Fire the projectile positively on the Z axis (forward)
            projectileRigidbody.velocity = newProjectile.transform.forward * projectileSpeed * 10f;
        }
        else
        {
            Debug.LogWarning("The projectile prefab does not have a Rigidbody component.");
        }
    }
}
