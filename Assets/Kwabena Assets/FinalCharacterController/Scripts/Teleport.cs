using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform  destination;
    public GameObject Player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Active");
        if (collider.CompareTag("Player"))
        {
            Player.SetActive(false);
            Player.transform.position = destination.position;
            Player.SetActive(true);
        } 
    }
}
