using UnityEngine;

public class TrapActivator : MonoBehaviour
{
    public Animator trapAnimator; // Reference to the Animator controlling the trap
    public string triggerName = "Activate"; // Name of the trigger parameter in the Animator
    public bool isTriggered = false; // Ensure the trap activates only once
    public float activationDelay = 0.5f; // Optional delay before the trap activates

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player") && !isTriggered)
        {
            // Mark as triggered to prevent reactivation
            isTriggered = true;

            // Optional delay before activating the trap
            Invoke("ActivateTrap", activationDelay);
        }
    }

    void ActivateTrap()
    {
        if (trapAnimator != null)
        {
            // Activate the trap by setting the Animator trigger
            trapAnimator.SetTrigger(triggerName);
            Debug.Log("Trap activated via Animator!");
        }
        else
        {
            Debug.LogError("Trap Animator not assigned!");
        }
    }
}
