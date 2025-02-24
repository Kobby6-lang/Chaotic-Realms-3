using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwabena.FinalCharacterController
{
    public class TrapOpen : MonoBehaviour
    {
        public GameObject TrapDoor;
        public float openingSpeed = 0.5f; // Adjust this value to slow down the animation
        public float delay = 1.0f; // Delay before the trap door opens

        private bool isOpening = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isOpening)
            {
                StartCoroutine(OpenTrapDoor());
            }
        }

        private IEnumerator OpenTrapDoor()
        {
            yield return new WaitForSeconds(delay);

            isOpening = true;
            Animation trapDoorAnimation = TrapDoor.GetComponent<Animation>();
            foreach (AnimationState state in trapDoorAnimation)
            {
                state.speed = openingSpeed;
            }
            trapDoorAnimation.Play();

            // Wait for the animation to play out before deactivating the collider
            yield return new WaitForSeconds(trapDoorAnimation.clip.length / openingSpeed);
            TrapDoor.GetComponent<Collider>().enabled = false;
            isOpening = false;
        }
    }
}







