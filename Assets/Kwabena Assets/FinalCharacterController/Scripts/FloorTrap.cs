using UnityEngine;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    public GameObject floorObject; // Reference to the floor object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trap area");
            Collider floorCollider = floorObject.GetComponent<Collider>();
            if (floorCollider != null)
            {
                floorCollider.enabled = false; // Disable the floor collider
            }
            else
            {
                Debug.LogError("Floor object does not have a Collider component");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trap area");
            Collider floorCollider = floorObject.GetComponent<Collider>();
            if (floorCollider != null)
            {
                floorCollider.enabled = true; // Re-enable the floor collider
            }
        }
    }
}

