using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    public float amplitude = 45f; // Maximum angle of rotation
    public float frequency = 1f; // Speed of the swinging motion
    private float initialRotation;

    void Start()
    {
        // Save the initial rotation of the wrecking ball
        initialRotation = transform.eulerAngles.x;
    }

    void Update()
    {
        // Calculate the new rotation angle using a sine wave for smooth swinging motion
        float angle = Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply the rotation to the x-axis
        transform.rotation = Quaternion.Euler(initialRotation + angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}









