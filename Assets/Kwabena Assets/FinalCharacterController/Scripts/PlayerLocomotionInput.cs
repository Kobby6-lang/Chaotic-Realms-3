using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Kwabena.FinalCharacterController 
{
    [DefaultExecutionOrder(-2)]
    public class PlayerLocomotionInput : MonoBehaviour, PlayerControls.IPlayerLocomotionMapActions
    {
        [SerializeField] private bool holdSprint = true;

        public bool SprintToggledOn {  get; private set; }
        public PlayerControls PlayerControls {  get; private set; }
        public Vector2 MovementInput { get; private set; }
        public Vector2 LookInput { get; private set; }




        private void OnEnable()
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();

            PlayerControls.PlayerLocomotionMap.Enable();
            PlayerControls.PlayerLocomotionMap.SetCallbacks(this);
        }

        private void OnDisable()
        {
            PlayerControls.PlayerLocomotionMap.Disable();
            PlayerControls.PlayerLocomotionMap.RemoveCallbacks(this);
        }
        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            Debug.Log("MovementInput");
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookInput = context.ReadValue<Vector2>();
        }

        public void OnToogleSprint(InputAction.CallbackContext context)
        {
            if (context.performed) 
            {
                SprintToggledOn = holdSprint || !SprintToggledOn;
            }
            else if (context.canceled) 
            {
                SprintToggledOn =  !holdSprint && SprintToggledOn;
            }
        }
    }
}   
