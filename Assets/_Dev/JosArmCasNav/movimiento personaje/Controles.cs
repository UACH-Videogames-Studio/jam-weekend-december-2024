//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/movimiento personaje/Controles.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controles: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Movimiento"",
            ""id"": ""0473484f-6494-4676-9dea-8b7711003697"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""PassThrough"",
                    ""id"": ""933235ed-b199-4679-9e62-2e559507fa07"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""9ff81d3e-df9b-425c-8d3c-8f0a7e1a58d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d3c31224-4c07-475a-a439-1f7a12086685"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a52463b0-8a97-4264-9371-649d1a5f7611"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a7c4cc2-870e-419c-b54b-1460e5732fd5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cacb36fc-155d-4814-ab28-cac5943eaa95"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89d62474-7cd9-43c6-baa8-cdfa2a5cf063"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Flechas"",
                    ""id"": ""cdd97f1f-09c5-4c08-9df7-ddfd6e0bc981"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ad134b5-6e21-41fe-9018-58e4dcddb83c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""860168d3-a31e-4c72-a430-4c0e6e0af5bf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""40fd8e89-e78d-430e-8947-07971b21dee5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7accef7d-3d02-4cc3-8255-9cc6577b408a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""34947015-5621-415e-b41b-97bdd1ad0a32"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movimiento
        m_Movimiento = asset.FindActionMap("Movimiento", throwIfNotFound: true);
        m_Movimiento_Mover = m_Movimiento.FindAction("Mover", throwIfNotFound: true);
        m_Movimiento_Saltar = m_Movimiento.FindAction("Saltar", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movimiento
    private readonly InputActionMap m_Movimiento;
    private List<IMovimientoActions> m_MovimientoActionsCallbackInterfaces = new List<IMovimientoActions>();
    private readonly InputAction m_Movimiento_Mover;
    private readonly InputAction m_Movimiento_Saltar;
    public struct MovimientoActions
    {
        private @Controles m_Wrapper;
        public MovimientoActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Movimiento_Mover;
        public InputAction @Saltar => m_Wrapper.m_Movimiento_Saltar;
        public InputActionMap Get() { return m_Wrapper.m_Movimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoActions set) { return set.Get(); }
        public void AddCallbacks(IMovimientoActions instance)
        {
            if (instance == null || m_Wrapper.m_MovimientoActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovimientoActionsCallbackInterfaces.Add(instance);
            @Mover.started += instance.OnMover;
            @Mover.performed += instance.OnMover;
            @Mover.canceled += instance.OnMover;
            @Saltar.started += instance.OnSaltar;
            @Saltar.performed += instance.OnSaltar;
            @Saltar.canceled += instance.OnSaltar;
        }

        private void UnregisterCallbacks(IMovimientoActions instance)
        {
            @Mover.started -= instance.OnMover;
            @Mover.performed -= instance.OnMover;
            @Mover.canceled -= instance.OnMover;
            @Saltar.started -= instance.OnSaltar;
            @Saltar.performed -= instance.OnSaltar;
            @Saltar.canceled -= instance.OnSaltar;
        }

        public void RemoveCallbacks(IMovimientoActions instance)
        {
            if (m_Wrapper.m_MovimientoActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovimientoActions instance)
        {
            foreach (var item in m_Wrapper.m_MovimientoActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovimientoActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovimientoActions @Movimiento => new MovimientoActions(this);
    public interface IMovimientoActions
    {
        void OnMover(InputAction.CallbackContext context);
        void OnSaltar(InputAction.CallbackContext context);
    }
}
