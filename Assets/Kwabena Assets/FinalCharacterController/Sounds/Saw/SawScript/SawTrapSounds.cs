//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SawTrapSounds : MonoBehaviour
//{
//    [Header("Trap Settings")]
//    [SerializeField] private int trapSoundIndex; // Index of the trap's sound effect
//    [SerializeField] private AudioSource trapAudioSource; // Unique AudioSource for this trap
//    private AudioManager audioManager; // Reference to AudioManager

//    private void Start()
//    {
//        // Validate and initialize the AudioManager
//        audioManager = FindObjectOfType<AudioManager>();
//        if (audioManager == null)
//        {
//            Debug.LogError("AudioManager not found in the scene! Ensure an AudioManager exists.");
//            return;
//        }

//        // Automatically activate the trap
//        ActivateTrap();
//    }

//    public void ActivateTrap()
//    {
//        // Trigger looping sound for the trap
//        if (audioManager != null && trapAudioSource != null)
//        {
//            audioManager.PlayLoopingTrapSound(trapSoundIndex, trapAudioSource);
//            Debug.Log($"Trap activated with looping sound (Index: {trapSoundIndex})!");
//        }
//        else
//        {
//            Debug.LogWarning("AudioManager or AudioSource is missing! Cannot activate trap sound.");
//        }
//    }

//    public void DeactivateTrap()
//    {
//        // Stop looping sound when trap is deactivated
//        if (audioManager != null && trapAudioSource != null)
//        {
//            audioManager.StopLoopingTrapSound(trapAudioSource);
//            Debug.Log("Trap deactivated and looping sound stopped!");
//        }
//        else
//        {
//            Debug.LogWarning("AudioManager or AudioSource is missing! Cannot deactivate trap sound.");
//        }
//    }
//}