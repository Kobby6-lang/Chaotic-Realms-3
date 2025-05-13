using UnityEngine;

public class Footstep : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager; // Reference to AudioManager
    [SerializeField] private CharacterController characterController; // Reference to CharacterController

    private void Start()
    {
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>(); // Find AudioManager in scene
        }

        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>(); // Get CharacterController
        }
    }

    public void PlayFootstep()
    {
        if (audioManager != null && characterController != null)
        {
            float speed = characterController.velocity.magnitude;

            if (speed > 0.1f && !audioManager.footstepSource.isPlaying)
            {
                audioManager.footstepSource.volume = audioManager.SFXSource.volume; // Sync footstep volume with SFX slider
                audioManager.PlaySFX(audioManager.running);
                audioManager.PlaySFX(audioManager.runBackwards);
                audioManager.PlaySFX(audioManager.strafeLeft);
                audioManager.PlaySFX(audioManager.strafeRight);
            }
            else if (speed <= 0.1f)
            {
                audioManager.StopSFX();
            }
        }
    }
}