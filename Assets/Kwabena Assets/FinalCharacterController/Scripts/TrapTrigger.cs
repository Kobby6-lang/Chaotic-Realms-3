using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public SequenceManager sequenceManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sequenceManager.StartCoroutine("ActivateTraps");
        }
    }
}

