using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // Assign your projectile prefab here
    public Transform spawnPoint; // Assign the spawn point here
    public float spawnInterval = 0.5f; // Time between projectiles
    public float projectileSpeed = 10f; // Adjust the projectile's speed here
    public float spawnOffset = 1f; // Distance from the spawn point tip

   
    private void Start()
    {
        // Begin spawning projectiles repeatedly
        InvokeRepeating(nameof(SpawnProjectile), 0f, spawnInterval);

    }
    private void SpawnProjectile()
    {
        // Calculate the position at the tip of the spawn point
        Vector3 tipPosition = spawnPoint.position + spawnPoint.forward * spawnOffset;

        // Instantiate the projectile at the calculated position
        GameObject projectile = Instantiate(projectilePrefab, tipPosition, projectilePrefab.transform.rotation);

        // Apply forward velocity if Rigidbody is attached
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = spawnPoint.forward * projectileSpeed; // Ensures it moves straight forward
        }

        // Destroy the projectile after a short duration to clean up
        Destroy(projectile, 3f);
    }
}