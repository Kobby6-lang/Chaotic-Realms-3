using UnityEngine;

public class ProjectileSpawnReverse : MonoBehaviour
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

        // Instantiate the projectile at the tip position
        GameObject projectile = Instantiate(projectilePrefab, tipPosition, spawnPoint.rotation);

        // Apply backward velocity if Rigidbody is attached
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -spawnPoint.forward * projectileSpeed; // Moves backward
        }

        // Destroy the projectile after 3 seconds to clean up
        Destroy(projectile, 0.4f);
    }
}
