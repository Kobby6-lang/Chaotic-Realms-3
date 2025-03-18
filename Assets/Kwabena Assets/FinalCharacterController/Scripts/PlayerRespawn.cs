using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // The position where the player will respawn
    private CharacterController characterController;

    private void Start()
    {
        // Reference the CharacterController component
        characterController = GetComponent<CharacterController>();

        if (respawnPoint == null)
        {
            // Set the default respawn point to the player's current position
            respawnPoint = transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a "Hazard"
        if (other.CompareTag("Hazard"))
        {
            RespawnAndResetLevel();
        }
    }

    private void RespawnAndResetLevel()
    {
        // Disable the CharacterController temporarily to avoid weird collisions
        characterController.enabled = false;

        // Move the player to the respawn point
        transform.position = respawnPoint.position;

        // Re-enable the CharacterController
        characterController.enabled = true;

        Debug.Log("Player has respawned at the respawn point.");
    }
}

