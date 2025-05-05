using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bones : MonoBehaviour
{
    public static int collectedBones = 0;
    private static int totalBones; // Track total bones collectively

    private void Start()
    {
        // Ensure totalBones is set once and correctly counts all Bones objects
        if (totalBones == 0)
        {
            totalBones = FindObjectsOfType<Bones>().Length;
            Debug.Log("Total bones detected in scene: " + totalBones);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            // Play sound effect
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.collectibleSound);
            }

            playerInventory.BonesCollected();
            gameObject.SetActive(false); // Hide the collectible

            // Increase the counter
            collectedBones++;
            Debug.Log("Bones collected so far: " + collectedBones + " / " + totalBones);

            // Check if all bones are collected
            if (collectedBones >= totalBones)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        Debug.Log("All bones collected! Game Over!");
        SceneManager.LoadScene("GameOverScene"); // Ensure "GameOverScene" exists in Build Settings
    }
}