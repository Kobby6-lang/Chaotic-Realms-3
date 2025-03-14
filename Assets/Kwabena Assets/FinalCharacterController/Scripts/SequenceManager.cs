using UnityEngine;
using System.Collections;

public class SequenceManager : MonoBehaviour
{
    public GameObject[] traps; // Array to hold the trap prefabs
    public float delayBetweenTraps = 1.0f; // Time delay between activating traps

    void Start()
    {
        StartCoroutine(ActivateTraps());
    }

    IEnumerator ActivateTraps()
    {
        for (int i = 0; i < traps.Length; i++)
        {
            MovingTrap movingTrap = traps[i].GetComponent<MovingTrap>();
            if (movingTrap != null)
            {
                Debug.Log("Activating trap: " + traps[i].name);
                StartCoroutine(ControlTrapMovement(movingTrap, i % 2 == 0));
            }
            else
            {
                Debug.LogError("MovingTrap script not found on: " + traps[i].name);
            }
            yield return new WaitForSeconds(delayBetweenTraps); // Wait before activating the next trap
        }
    }

    IEnumerator ControlTrapMovement(MovingTrap trap, bool startMovingUp)
    {
        trap.enabled = true; // Enable the trap's movement
        trap.movingUp = startMovingUp; // Set the initial direction of the trap
        while (true)
        {
            yield return null;
        }
    }
}




