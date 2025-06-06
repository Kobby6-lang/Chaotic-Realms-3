// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Key Rebind/RebindJumping.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Kwabena.FinalCharacterController;


namespace Kwabena.FinalCharacterController 
{
    public class @RebindJumping : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @RebindJumping()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""RebindJumping"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""35b8ea24-45cf-4166-b1c7-360b6c415d71"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b2af7336-b120-42bd-92c0-5670b09de81e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""af755a11-fbad-44c5-8d20-c71087726b50"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f0cc941-22cc-433b-9434-d0731abb9dcc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // PLayerControls
            m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
            m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // GameControls
        private readonly InputActionMap m_PlayerControls;
        private IPlayerLocomotionMap m_PlayerControlsActionsCallbackInterface;
        private readonly InputAction m_PlayerControls_Jump;
        public struct PlayerControlsActions
        {
            private @RebindJumping m_Wrapper;
            public PlayerControlsActions(@RebindJumping wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerLocomotionMap instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public PlayerControlsActions PlayerControls => new PlayerControlsActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IPlayerLocomotionMap
        {
            void OnJump(InputAction.CallbackContext context);
        }
    }

}
