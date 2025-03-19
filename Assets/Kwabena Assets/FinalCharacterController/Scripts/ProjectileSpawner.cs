using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
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
        // Calculate the position at the tip of the spawn point
        Vector3 tipPosition = spawnPoint.position + spawnPoint.forward * spawnOffset;

        // Instantiate the projectile without overriding its original transform
        GameObject projectile = Instantiate(projectilePrefab);

        // Retain the projectile's original transform, but set its position at the spawn point tip
        projectile.transform.position = tipPosition;

        // Optionally, rotate the projectile to face the same direction as the spawn point
        projectile.transform.rotation = projectilePrefab.transform.rotation; // Keeps original rotation

        // Apply forward velocity if Rigidbody is attached
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = spawnPoint.forward * projectileSpeed; // Ensures it moves straight forward
        }

        // Destroy the projectile after 3 seconds to clean up
        Destroy(projectile, 0.5f);
    }
}
