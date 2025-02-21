using UnityEngine;
using System.Collections;

public class PlayerSplat : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isSplat = false;
    public Transform respawnPoint; // Reference to the respawn point

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player collides with the ground (or any specific object)
        if (hit.gameObject.CompareTag("Ground") && !isSplat)
        {
            // Create a "splat" effect by changing the player's scale
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.1f, originalScale.z);
            isSplat = true;

            // Optionally, disable the CharacterController to stop further movement
            GetComponent<CharacterController>().enabled = false;

            // Start the respawn process
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        // Wait for a short delay before respawning
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed

        // Reset the player's scale
        transform.localScale = originalScale;

        // Move the player to the respawn point
        transform.position = respawnPoint.position;

        // Re-enable the CharacterController
        GetComponent<CharacterController>().enabled = true;

        // Reset the splat flag
        isSplat = false;
    }
}