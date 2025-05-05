using UnityEngine;

public class Bones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.collectibleSound);
            }

            playerInventory.BonesCollected();
            gameObject.SetActive(false); // Hide the collectible

            // Use GameManager to track collectibles
            GameManager.Instance.CollectBone();
        }
    }
}