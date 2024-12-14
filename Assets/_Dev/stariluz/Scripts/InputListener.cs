using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/* This class should include all the potential inputs that should be listened */
public class InputListener : MonoBehaviour
{
    private bool keyPressed;
    private Vector2 direction;

    public Controles input;
      
    private void Awake()
    {
        input = new();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Movimiento.Saltar.started += _ => RecordJump();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Movimiento.Saltar.started -= _ => RecordJump();
    }

    public void RecordJump()
    {
        keyPressed = true;
    }
    public void GetInputs()
    {
        direction=input.Movimiento.Mover.ReadValue<Vector2>();
    }

    public InputObject GetInputObject()
    {
        return new InputObject(direction, keyPressed);
    }

    public void ResetInput()
    {
        direction=Vector2.zero;
        keyPressed = false;
    }


}

