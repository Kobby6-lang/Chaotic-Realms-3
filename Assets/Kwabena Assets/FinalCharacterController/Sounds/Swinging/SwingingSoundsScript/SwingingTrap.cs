using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingTrap : MonoBehaviour
{
    [Header("Trap Settings")]
    [SerializeField] private int trapSoundIndex; // Index of the trap's sound effect
    private AudioManager audioManager; // Reference to AudioManager

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        ActivateTrap();
    }

    public void ActivateTrap()
    {
        // Trigger looping sound for the trap
        if (audioManager != null)
        {
            audioManager.PlayLoopingTrapSound(trapSoundIndex);
        }

        Debug.Log("Trap activated with looping sound!");
    }
    public void DeactivateTrap()
    {
        // Stop looping sound when trap is deactivated
        if (audioManager != null)
        {
            audioManager.StopLoopingTrapSound();
        }

        Debug.Log("Trap deactivated and looping sound stopped!");
    }
}
