using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed of the trap's movement
    public float moveHeight = 2.0f; // Height of the vertical movement
    public bool movingUp = true; // Public variable to control movement direction
    private Vector3 initialPosition;


    void Start()
    {
        initialPosition = transform.position;
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



