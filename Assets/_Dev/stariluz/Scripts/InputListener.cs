using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/* This class should include all the potential inputs that should be listened */
public class InputListener : MonoBehaviour
{
    private Vector2 direction;

    public GhostControls input;
      
    private void Awake()
    {
        input = new();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    public void GetInputs()
    {
        direction=input.Movement.Move.ReadValue<Vector2>();
    }

    public InputObject GetInputObject()
    {
        return new InputObject(direction);
    }

    public void ResetInput()
    {
        direction=Vector2.zero;
    }


}

