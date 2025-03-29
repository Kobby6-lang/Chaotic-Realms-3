using UnityEngine;
using UnityEngine.EventSystems;

public class DotNavigator : MonoBehaviour
{
    public RectTransform dot; // Assign the dot UI element

    public float xOffset = -50f; // Adjust this value for alignment with the beginning

    void Update()
    {
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject != null)
        {
            RectTransform selectedRect = selectedObject.GetComponent<RectTransform>();
            if (selectedRect != null)
            {
                // Adjust the dot's position to the left of the menu item
                Vector3 targetPosition = selectedRect.position;
                targetPosition.x += xOffset; // Add the offset to move the dot to the left
                dot.position = targetPosition;
            }
        }
    }
}