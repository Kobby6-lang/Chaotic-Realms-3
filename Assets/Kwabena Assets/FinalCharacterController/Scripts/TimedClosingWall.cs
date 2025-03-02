using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class TimedClosingWall : MonoBehaviour
{
    [SerializeField] private Vector3 closedPosition; // Target position when the wall is closed
    [SerializeField] private float closingSpeed = 2f; // Speed of the wall's movement
    [SerializeField] private float delayBeforeClosing = 3f; // Delay before the wall starts moving

    private Vector3 initialPosition; // Wall's starting position
    private bool isClosing = false;

    private void Start()
    {
        // Save the initial position of the wall
        initialPosition = transform.position;

        // Start the closing process after the delay
        Invoke(nameof(StartClosing), delayBeforeClosing);
    }

    private void Update()
    {
        if (isClosing)
        {
            // Move the wall towards the closed position
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, closingSpeed * Time.deltaTime);
        }
    }

    private void StartClosing()
    {
        isClosing = true; // Begin closing the wall
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is caught by the wall
        if (other.CompareTag("Player"))
        {
            ResetLevel(); // Reset the entire level
        }
    }

    private void ResetLevel()
    {
        // Reload the active scene to reset the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




