using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public Vector2 movement;

    private Rigidbody2D rb2D;

    public float velocidadMovimiento;

    public bool mirandoDerecha = true;

    public float fuerzaSalto;

    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;

    public Transform initialAnchorPoint;

    public void GivenInputs(InputObject inputs)
    {
        movement = inputs.movement;
    }

    private void Start(){
        transform.position=initialAnchorPoint.position;
        rb2D=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (movement.magnitude != 0)
        {
            AdjustFaceOrientation(movement.x);
            enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(movement.x,movement.y)*velocidadMovimiento;
    }

    private void AdjustFaceOrientation(float movementX)
    {
        if (movementX > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (movementX < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
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