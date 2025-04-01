using UnityEngine;

public class RotateAroundZAxis : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the GameObject around its Z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
