using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputObject
{

    public Vector2 movement;

    public InputObject(Vector2 movement, bool isBtnPressed)
    {
        this.movement = movement;

    }

}