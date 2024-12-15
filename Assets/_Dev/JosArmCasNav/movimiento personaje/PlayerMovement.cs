using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controls controls;

    public Vector2 direction;

    public Rigidbody2D rb2D;

    public float movSpeed;

    public bool lookRight = true;

    public float jumpForce;

    public LayerMask whatIsFloor;
    public Transform floorController;
    public Vector3 boxDimensions;
    public bool onFloor;

    private void Awake()
    {
        controls = new();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Movement.Jump.started += _ => Jump();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Movement.Jump.started -= _ => Jump();
    }

    private void Update()
    {
        direction = controls.Movement.Move.ReadValue<Vector2>();

        AdjustRotation(direction.x);

        onFloor = Physics2D.OverlapBox(floorController.position, boxDimensions, 0f, whatIsFloor);
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(direction.x * movSpeed, rb2D.velocity.y);
    }

    private void AdjustRotation(float directionX)
    {
        if(directionX > 0 && !lookRight){
            Flip();
        }else if(directionX < 0 && lookRight){
            Flip();
        }
    }

    private void Flip()
    {
        lookRight = !lookRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        if (onFloor)
        {
        rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorController.position, boxDimensions);
    }
}