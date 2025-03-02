using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // For resetting the level

namespace Kwabena.FinalCharacterController 
{
    public class TimedClosingWall : MonoBehaviour
    {
        [SerializeField] private Vector3 closedPosition; // Target position when the wall is closed
        [SerializeField] private float closingSpeed = 2f; // Speed of the wall's movement
        [SerializeField] private float delayBeforeClosing = 3f; // Delay before the wall starts moving

        private Vector3 initialPosition; // Wall's starting position
        private bool isClosing = false;

        void Start()
        {
            // Save the initial position of the wall
            initialPosition = transform.position;

            // Start the closing process after the delay
            Invoke(nameof(StartClosing), delayBeforeClosing);
        }

        void Update()
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
                KillPlayerAndResetLevel(other.gameObject); // Trigger level reset
            }
        }

        private void KillPlayerAndResetLevel(GameObject player)
        {
            StartCoroutine(SquashAndResetLevel(player)); // Start the squash and reset process
        }

        private IEnumerator SquashAndResetLevel(GameObject player)
        {
            // Cache original player scale
            Vector3 originalScale = player.transform.localScale;

            // Squash the player
            player.transform.localScale = new Vector3(originalScale.x * 3f, originalScale.y * 0.13f, originalScale.z);

            // Disable the player's CharacterController to stop movement
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null) controller.enabled = false;

            // Wait for a short delay
            yield return new WaitForSeconds(1.0f);

            // Reset the entire level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



}
