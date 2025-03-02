using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] GameObject floorIntact; // Reference to the intact floor object
    [SerializeField] GameObject floorBroken; // Reference to the broken floor object
    [SerializeField] AudioClip breakSound; // Reference to the sound effect for breaking

    private BoxCollider bc;
    private bool isBroken = false; // Ensure the object only breaks once

    private void Awake()
    {
        bc = GetComponent<BoxCollider>();
    }

    // Trigger the break when the player steps on it
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBroken) // Ensure it's the player and not already broken
        {
            Break();
        }
    }

    private void Break()
    {
        isBroken = true; // Mark as broken
        floorIntact.SetActive(false); // Hide the intact floor
        floorBroken.SetActive(true); // Show the broken floor
        bc.enabled = false; // Disable the collider

        // Play the breaking sound
        if (breakSound != null)
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
    }
}


