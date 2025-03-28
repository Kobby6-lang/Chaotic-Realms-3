using UnityEngine;

public class FallingProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab here
    public Transform spawnPoint; // Assign the spawn point here
    public float spawnInterval = 0.5f; // Time between projectiles
    public float projectileSpeed = 10f; // Adjust the projectile's speed here
    public float spawnOffset = 1f; // Distance from the spawn point tip

    void Start()
    {
        // Repeatedly spawn projectiles at the set interval
        InvokeRepeating("SpawnProjectile", 0f, spawnInterval);
    }

    void SpawnProjectile()
    {
        // Calculate the position below the spawn point
        Vector3 tipPosition = spawnPoint.position - spawnPoint.up * spawnOffset;

        // Instantiate the projectile without overriding its original transform
        GameObject projectile = Instantiate(projectilePrefab);

        // Set the position of the projectile below the spawn point
        projectile.transform.position = tipPosition;

        // Optionally, rotate the projectile to face downward
        projectile.transform.rotation = Quaternion.LookRotation(-spawnPoint.up); // Rotates downward

        // Apply downward velocity if Rigidbody is attached
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -spawnPoint.up * projectileSpeed; // Ensures it shoots straight down
        }

        // Destroy the projectile after a short duration to clean up
        Destroy(projectile, 3f); // Adjust the lifetime as needed
    }
}
