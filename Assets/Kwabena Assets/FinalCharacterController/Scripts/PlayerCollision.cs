using UnityEngine;

public class PlayerSplat : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isSplat = false;

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

            // Optionally, destroy the player object after a short delay
            Destroy(gameObject, 1.0f); // Adjust the delay as needed
        }
    }
}