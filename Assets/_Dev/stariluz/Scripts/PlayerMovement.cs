using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stariluz
{
    public class PlayerMovement : MonoBehaviour
    {
        public Controls controls;

        public Vector2 direction;

        public float movSpeed;

        public bool lookRight = true;

        public float jumpForce;

        public LayerMask whatIsFloor;
        public Transform floorController;
        public Vector3 boxDimensions;
        public bool onFloor;
        public bool isJumping=false;
        public bool checkFloor=true;

        public bool spriteOrientationIsRight = true;

        private Rigidbody2D rb2D;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

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
            if (direction.magnitude > 0)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
            AdjustRotation(direction.x);

            onFloor = Physics2D.OverlapBox(floorController.position, boxDimensions, 0f, whatIsFloor);
            if(onFloor&&isJumping&&checkFloor){
                isJumping=false;
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }
        }

        private void FixedUpdate()
        {
            rb2D.velocity = new Vector2(direction.x * movSpeed, rb2D.velocity.y);
        }

        private void AdjustRotation(float movementX)
        {
            if (movementX > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementX < 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        private void Jump()
        {
            if (onFloor)
            {
                checkFloor=false;
                StartCoroutine(JumpCooldown(1f));
                isJumping=true;
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsFalling", true);
                rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        private IEnumerator JumpCooldown(float seconds){
            yield return new WaitForSeconds(seconds);
            checkFloor=true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(floorController.position, boxDimensions);
        }
    }

}