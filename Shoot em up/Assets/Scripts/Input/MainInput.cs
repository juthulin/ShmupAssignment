// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/MainInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInput"",
    ""maps"": [
        {
            ""name"": ""MainScene"",
            ""id"": ""c4ed097f-dc33-4f32-bf4c-38f526532a75"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""919a7f62-909a-42a1-be61-16a48713bb0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""f90faa5b-04df-4a3c-b637-d402b30ac6bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDeltaX"",
                    ""type"": ""Value"",
                    ""id"": ""f18060e6-253b-4e7c-8b53-f29ac2d482b7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRightClick"",
                    ""type"": ""Button"",
                    ""id"": ""3ff76e91-9181-4478-9e68-8fd09eb20e09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeaponPositive"",
                    ""type"": ""Button"",
                    ""id"": ""9853984c-181e-45b8-b173-629ccd3a023f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeaponNegative"",
                    ""type"": ""Button"",
                    ""id"": ""e89e12db-27b6-4357-a9a6-d8d07a5bbbab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseEquipment"",
                    ""type"": ""Button"",
                    ""id"": ""933b7022-cce3-4aad-afb2-78fd610fd28e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b39bac9f-391f-428c-b176-f3c8c4128ce2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5fbc26ea-7d0c-4edc-978c-42c15a5c88b2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a6849094-b2fb-4bf4-a2e7-edfdcae28c70"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2d51ad9e-74f3-429a-9714-18e8431b024e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ab805b1-7217-4213-8d6d-a63943a27291"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""418a22aa-6b42-44db-9230-36d9b6bd23a8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ba0e2f6-9590-4b02-a18f-09f570a29655"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11e53887-2cd9-425b-b0a8-ee9a6bfbb9f3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MouseDeltaX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""267f3c72-13d9-4682-ae0b-2888647cd468"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MouseRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af266b29-184c-4644-ba67-99121cc87006"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SwitchWeaponPositive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b153004-e525-45c7-872a-0292983b35c3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeaponNegative"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb0f9621-e221-4416-a7b3-b690f5941575"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""UseEquipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
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
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
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
        // MainScene
        m_MainScene = asset.FindActionMap("MainScene", throwIfNotFound: true);
        m_MainScene_Movement = m_MainScene.FindAction("Movement", throwIfNotFound: true);
        m_MainScene_Shooting = m_MainScene.FindAction("Shooting", throwIfNotFound: true);
        m_MainScene_MouseDeltaX = m_MainScene.FindAction("MouseDeltaX", throwIfNotFound: true);
        m_MainScene_MouseRightClick = m_MainScene.FindAction("MouseRightClick", throwIfNotFound: true);
        m_MainScene_SwitchWeaponPositive = m_MainScene.FindAction("SwitchWeaponPositive", throwIfNotFound: true);
        m_MainScene_SwitchWeaponNegative = m_MainScene.FindAction("SwitchWeaponNegative", throwIfNotFound: true);
        m_MainScene_UseEquipment = m_MainScene.FindAction("UseEquipment", throwIfNotFound: true);
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

    // MainScene
    private readonly InputActionMap m_MainScene;
    private IMainSceneActions m_MainSceneActionsCallbackInterface;
    private readonly InputAction m_MainScene_Movement;
    private readonly InputAction m_MainScene_Shooting;
    private readonly InputAction m_MainScene_MouseDeltaX;
    private readonly InputAction m_MainScene_MouseRightClick;
    private readonly InputAction m_MainScene_SwitchWeaponPositive;
    private readonly InputAction m_MainScene_SwitchWeaponNegative;
    private readonly InputAction m_MainScene_UseEquipment;
    public struct MainSceneActions
    {
        private @MainInput m_Wrapper;
        public MainSceneActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MainScene_Movement;
        public InputAction @Shooting => m_Wrapper.m_MainScene_Shooting;
        public InputAction @MouseDeltaX => m_Wrapper.m_MainScene_MouseDeltaX;
        public InputAction @MouseRightClick => m_Wrapper.m_MainScene_MouseRightClick;
        public InputAction @SwitchWeaponPositive => m_Wrapper.m_MainScene_SwitchWeaponPositive;
        public InputAction @SwitchWeaponNegative => m_Wrapper.m_MainScene_SwitchWeaponNegative;
        public InputAction @UseEquipment => m_Wrapper.m_MainScene_UseEquipment;
        public InputActionMap Get() { return m_Wrapper.m_MainScene; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainSceneActions set) { return set.Get(); }
        public void SetCallbacks(IMainSceneActions instance)
        {
            if (m_Wrapper.m_MainSceneActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMovement;
                @Shooting.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnShooting;
                @Shooting.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnShooting;
                @Shooting.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnShooting;
                @MouseDeltaX.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMouseDeltaX;
                @MouseDeltaX.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMouseDeltaX;
                @MouseDeltaX.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMouseDeltaX;
                @MouseRightClick.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnMouseRightClick;
                @SwitchWeaponPositive.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnSwitchWeaponPositive;
                @SwitchWeaponPositive.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnSwitchWeaponPositive;
                @SwitchWeaponPositive.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnSwitchWeaponPositive;
                @SwitchWeaponNegative.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnSwitchWeaponNegative;
                @SwitchWeaponNegative.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnSwitchWeaponNegative;
                @SwitchWeaponNegative.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnSwitchWeaponNegative;
                @UseEquipment.started -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnUseEquipment;
                @UseEquipment.performed -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnUseEquipment;
                @UseEquipment.canceled -= m_Wrapper.m_MainSceneActionsCallbackInterface.OnUseEquipment;
            }
            m_Wrapper.m_MainSceneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shooting.started += instance.OnShooting;
                @Shooting.performed += instance.OnShooting;
                @Shooting.canceled += instance.OnShooting;
                @MouseDeltaX.started += instance.OnMouseDeltaX;
                @MouseDeltaX.performed += instance.OnMouseDeltaX;
                @MouseDeltaX.canceled += instance.OnMouseDeltaX;
                @MouseRightClick.started += instance.OnMouseRightClick;
                @MouseRightClick.performed += instance.OnMouseRightClick;
                @MouseRightClick.canceled += instance.OnMouseRightClick;
                @SwitchWeaponPositive.started += instance.OnSwitchWeaponPositive;
                @SwitchWeaponPositive.performed += instance.OnSwitchWeaponPositive;
                @SwitchWeaponPositive.canceled += instance.OnSwitchWeaponPositive;
                @SwitchWeaponNegative.started += instance.OnSwitchWeaponNegative;
                @SwitchWeaponNegative.performed += instance.OnSwitchWeaponNegative;
                @SwitchWeaponNegative.canceled += instance.OnSwitchWeaponNegative;
                @UseEquipment.started += instance.OnUseEquipment;
                @UseEquipment.performed += instance.OnUseEquipment;
                @UseEquipment.canceled += instance.OnUseEquipment;
            }
        }
    }
    public MainSceneActions @MainScene => new MainSceneActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IMainSceneActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShooting(InputAction.CallbackContext context);
        void OnMouseDeltaX(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnSwitchWeaponPositive(InputAction.CallbackContext context);
        void OnSwitchWeaponNegative(InputAction.CallbackContext context);
        void OnUseEquipment(InputAction.CallbackContext context);
    }
}
