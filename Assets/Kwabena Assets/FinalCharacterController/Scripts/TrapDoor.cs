using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public float openingSpeed;
    public float rotateDirection;
    private bool playerOn = false;

    // Update is called once per frame
    void Update()
    {
        if (playerOn) 
        {
            transform.parent.Rotate(openingSpeed * Time.deltaTime * rotateDirection, 0, 0);
        }
    }

    public void Open()
    {
        playerOn = true;
    }
}
