using Kwabena.FinalCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwabena.FinalCharacterController
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator; // Reference to the Animator component
        [SerializeField] private float locomotionBlendSpeed = 4f; // Speed of blending between animations

        private PlayerLocomotionInput _playerLocomotionInput; // Reference to the PlayerLocomotionInput component
        private PlayerState _playerState; // Reference to the PlayerState component
        private PlayerController _playerController; // Reference to the PlayerController component

        // Animator parameter hashes
        private static int inputXHash = Animator.StringToHash("inputX");
        private static int inputYHash = Animator.StringToHash("inputY");
        private static int inputMagnitudeHash = Animator.StringToHash("inputMagnitude");
        private static int isIdlingHash = Animator.StringToHash("isIdling");
        private static int isGroundedHash = Animator.StringToHash("isGrounded");
        private static int isFallingHash = Animator.StringToHash("isFalling");
        private static int isJumpingHash = Animator.StringToHash("isJumping");
        private static int isRotatingToTargetHash = Animator.StringToHash("isRotatingToTarget");
        private static int rotationMismatchHash = Animator.StringToHash("rotationMismatch");
        private static int isCrouchingHash = Animator.StringToHash("isCrouching"); // New parameter for crouching

        private Vector3 _currentBlendInput = Vector3.zero; // Current blend input for movement

        private float _sprintMaxBlendValue = 1.5f; // Max blend value for sprinting
        private float _runMaxBlendValue = 1.0f; // Max blend value for running
        private float _walkMaxBlendValue = 0.5f; // Max blend value for walking
        private float _crouchMaxBlendValue = 0.5f; // Max blend value for crouching

        private void Awake()
        {
            // Get references to other components
            _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
            _playerState = GetComponent<PlayerState>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            UpdateAnimationState(); // Update the animation state each frame
        }

        private void UpdateAnimationState()
        {
            // Get the current player movement state
            bool isIdling = _playerState.CurrentPlayerMovementState == PlayerMovementState.Idling;
            bool isRunning = _playerState.CurrentPlayerMovementState == PlayerMovementState.Running;
            bool isSprinting = _playerState.CurrentPlayerMovementState == PlayerMovementState.Sprinting;
            bool isJumping = _playerState.CurrentPlayerMovementState == PlayerMovementState.Jumping;
            bool isFalling = _playerState.CurrentPlayerMovementState == PlayerMovementState.Falling;
            bool isGrounded = _playerState.InGroundedState();
            bool isCrouching = _playerLocomotionInput.CrouchToggledOn; // Check if crouching

            // Determine the blend input based on the current movement state
            bool isRunBlendValue = isRunning || isJumping || isFalling;
            Vector2 inputTarget = isSprinting ? _playerLocomotionInput.MovementInput * _sprintMaxBlendValue :
                                 isRunBlendValue ? _playerLocomotionInput.MovementInput * _runMaxBlendValue :
                                 isCrouching ? _playerLocomotionInput.MovementInput * _crouchMaxBlendValue : // Adjust for crouching
                                 _playerLocomotionInput.MovementInput * _walkMaxBlendValue;

            // Smoothly blend the input values
            _currentBlendInput = Vector3.Lerp(_currentBlendInput, inputTarget, locomotionBlendSpeed * Time.deltaTime);

            // Set animator parameters
            _animator.SetBool(isGroundedHash, isGrounded);
            _animator.SetBool(isIdlingHash, isIdling);
            _animator.SetBool(isFallingHash, isFalling);
            _animator.SetBool(isJumpingHash, isJumping);
            _animator.SetBool(isRotatingToTargetHash, _playerController.IsRotatingToTarget);
            _animator.SetBool(isCrouchingHash, isCrouching); // Set crouching state

            // Update movement input
            _animator.SetFloat(inputXHash, _currentBlendInput.x);
            _animator.SetFloat(inputYHash, _currentBlendInput.y);
            _animator.SetFloat(inputMagnitudeHash, _currentBlendInput.magnitude);
            _animator.SetFloat(rotationMismatchHash, _playerController.RotationMismatch);
        }
    }
}
