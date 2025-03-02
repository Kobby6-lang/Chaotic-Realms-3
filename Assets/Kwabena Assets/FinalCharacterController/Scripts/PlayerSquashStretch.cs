using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // For resetting the level

public class PlayerSquashStretch : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isSquashed = false;
    public Transform respawnPoint; // Reference to the respawn point

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player collides with the ground (or any specific object)
        if (hit.gameObject.CompareTag("Ground") && !isSquashed)
        {
            // Create a "squash and stretch" effect by changing the player's scale
            transform.localScale = new Vector3(originalScale.x * 3f, originalScale.y * 0.13f, originalScale.z);
            isSquashed = true;

            // Optionally, disable the CharacterController to stop further movement
            GetComponent<CharacterController>().enabled = false;

            // Start the level reset process
            StartCoroutine(ResetLevel());
        }
    }

    IEnumerator ResetLevel()
    {
        // Wait for a short delay before resetting the level
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed

        // Reset the entire level by reloading the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
