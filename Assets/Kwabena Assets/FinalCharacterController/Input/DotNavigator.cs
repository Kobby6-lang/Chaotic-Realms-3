using UnityEngine;
using UnityEngine.EventSystems;

public class DotNavigator : MonoBehaviour
{
    public RectTransform dot; // Assign the dot UI element
    public float xOffset = -50f; // Adjust this value for alignment with the beginning

    [Header("Audio")]
    public AudioSource audioSource; // Assign the audio source for navigation sounds
    public AudioClip navigationSound; // Assign the navigation sound effect

    private GameObject lastSelectedObject; // Track the last selected UI element

    void Update()
    {
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject != null && selectedObject != lastSelectedObject) // Check if selection has changed
        {
            RectTransform selectedRect = selectedObject.GetComponent<RectTransform>();
            if (selectedRect != null)
            {
                // Adjust the dot's position to the left of the menu item
                Vector3 targetPosition = selectedRect.position;
                targetPosition.x += xOffset; // Add the offset to move the dot to the left
                dot.position = targetPosition;

                // Play navigation sound effect when switching menu items
                if (audioSource != null && navigationSound != null)
                {
                    audioSource.PlayOneShot(navigationSound);
                }

                lastSelectedObject = selectedObject; // Update last selected item
            }
        }
    }
}