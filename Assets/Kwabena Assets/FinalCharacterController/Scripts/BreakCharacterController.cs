using UnityEngine;

public class BreakCharacterController : MonoBehaviour
{
    public GameObject shatteredVersion; // Prefab for the shattered pieces
    public float explosionForce = 500f; // Force applied to the pieces
    public float explosionRadius = 5f;  // Radius of the explosion

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player is hit by a specific "Hazard" object
        if (hit.gameObject.tag == "Hazard") // Change "Hazard" to match your tag
        {
            // Spawn the shattered version at the player's position
            GameObject shattered = Instantiate(shatteredVersion, transform.position, transform.rotation);

            // Add explosion force to each piece of the shattered version
            foreach (Rigidbody rb in shattered.GetComponentsInChildren<Rigidbody>())
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Disable the CharacterController to simulate destruction
            gameObject.SetActive(false);
        }
    }
}
















