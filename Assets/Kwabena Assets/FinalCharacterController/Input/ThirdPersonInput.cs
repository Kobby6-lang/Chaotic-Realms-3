using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;



namespace Kwabena.FinalCharacterController
{
    [DefaultExecutionOrder(-2)]
    public class ThirdPersonInput : MonoBehaviour, PlayerControls.IThirdPersonMapActions
    {
        #region Class Variables

        public float ScrollInput { get; private set; }

        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private float _cameraZoomSpeed = 0.2f;

        #endregion

        #region Startup

        private void Awake()
        {
            //_thirdPersonFollow = _virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        }
        private void OnEnable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player Controls is not initialized - Cannot enable");
                return;
            }

            //PlayerInputManager.Instance.PlayerControls.ThirdPersonMap.Enable();
            //PlayerInputManager.Instance.PlayerControls.ThirdPersonMap.SetCallbacks(this);
        }

        private void OnDisable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player Controls is not initialized - Cannot disable");
                return;
            }
            //PlayerInputManager.Instance.PlayerControls.ThirdPersonMap.Disable();
            //PlayerInputManager.Instance.PlayerControls.ThirdPersonMap.RemoveCallbacks(this);
        }
        #endregion

        #region Update
        private void Update()
        {
            //_thirdPersonFollow.CameraDistance = Mathf.Clamp(_thirdPersonFollow.CameraDistance + ScrollInput, _cameraMinZoom, _cameraMaxZoom);
        }

        private void LateUpdate()
        {
            ScrollInput = new();
        }
        #endregion

        #region Input Callbacks
        public void OnScrollCamera(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            float scrollInput = context.ReadValue<float>();
            ScrollInput = 1f * scrollInput * _cameraZoomSpeed;
        }
        #endregion
    }
}