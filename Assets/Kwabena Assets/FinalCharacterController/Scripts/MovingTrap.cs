using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed of the trap's movement
    public float moveHeight = 2.0f; // Height of the vertical movement
    public bool movingUp = true; // Public variable to control movement direction
    private Vector3 initialPosition;

    [Header("Trap Settings")]
    [SerializeField] private int trapSoundIndex; // Index of the trap's sound effect
    private AudioManager audioManager; // Reference to AudioManager


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        initialPosition = transform.position;
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
    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= initialPosition.y + moveHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= initialPosition.y - moveHeight)
            {
                movingUp = true;
            }
        }
    }
}



