using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollision : MonoBehaviour
{
    public CharacterController characterController; // Assign the CharacterController in the Inspector
    private Vector3 originalScale;
    private bool isSplat = false;
    private Vector2 moveInput;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (!isSplat)
        {
            // Handle player movement here using the CharacterController
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
            characterController.Move(move * Time.deltaTime);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player collides with the ground (or any specific object)
        if (hit.gameObject.tag == "Ground")
        {
            // Create a "splat" effect by changing the player's scale
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.1f, originalScale.z);
            isSplat = true;

            // Optionally, disable the CharacterController to stop movement
            characterController.enabled = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
