using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public float movementSpeed;

    public bool isLookingRight = true;

    public Transform initialAnchorPoint;


    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    private void Start(){
        transform.position=initialAnchorPoint.position;
        rb2D=GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (movement.magnitude != 0)
        {
            AdjustFaceOrientation(movement.x);
        }
    }
    
    public void GivenInputs(InputObject inputs)
    {
        movement = inputs.movement;
    }


    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(movement.x,movement.y)*movementSpeed;
    }

    private void AdjustFaceOrientation(float movementX)
    {
        if (movementX > 0 && !isLookingRight)
        {
            spriteRenderer.flipX=true;
        }
        else if (movementX < 0 && isLookingRight)
        {
            spriteRenderer.flipX=false;
        }
    }
    
    public void ResetInputs()
    {
        movement = Vector2.zero;
    }

    public void Reset()
    {
        ResetInputs();
        transform.position = initialAnchorPoint.position;
    }
}