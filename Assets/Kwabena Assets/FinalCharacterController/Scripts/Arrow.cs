using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f; // Adjust the speed of the arrow

    void Update()
    {
        // Move the arrow forward
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Stop the arrow and destroy it on collision
        Destroy(gameObject);
    }
}

