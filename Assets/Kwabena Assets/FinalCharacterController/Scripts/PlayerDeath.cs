using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint; // The position where the player will respawn
    public Animator animator; // Reference to the Animator component
    private CharacterController characterController;

    private bool isDead = false; // Track if the player is currently "dead"

    private void Start()
    {
        // Reference the CharacterController component
        characterController = GetComponent<CharacterController>();

        if (respawnPoint == null)
        {
            // Set the default respawn point to the player's current position
            respawnPoint = transform;
        }

        if (animator == null)
        {
            // Automatically find the Animator component if not assigned
            animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a "Hazard"
        if (other.CompareTag("Hazard") && !isDead)
        {
            StartCoroutine(HandleDeath());
        }
    }

    private System.Collections.IEnumerator HandleDeath()
    {
        isDead = true;

        // Play the death animation
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Wait for the animation to finish (adjust the delay to match your animation length)
        yield return new WaitForSeconds(2.0f);

        // Respawn the player
        RespawnPlayer();

        isDead = false;
    }

    private void RespawnPlayer()
    {
        // Disable the CharacterController temporarily to avoid issues
        characterController.enabled = false;

        // Move the player to the respawn point
        transform.position = respawnPoint.position;

        // Re-enable the CharacterController
        characterController.enabled = true;

        Debug.Log("Player has respawned at the respawn point.");
    }
}


