using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Controles controles;

    public Vector2 direccion;

    public Rigidbody2D rb2D;

    public float velocidadMovimiento;

    public bool mirandoDerecha = true;

    public float fuerzaSalto;

    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;

    private void Awake()
    {
        controles = new();
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.Movimiento.Saltar.started += _ => Saltar();
    }

    private void OnDisable()
    {
        controles.Disable();
        controles.Movimiento.Saltar.started -= _ => Saltar();
    }

    private void Update()
    {
        direccion = controles.Movimiento.Mover.ReadValue<Vector2>();

        AjustarRotacion(direccion.x);

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(direccion.x * velocidadMovimiento, rb2D.velocity.y);
    }

    private void AjustarRotacion(float direccionX)
    {
        if(direccionX > 0 && !mirandoDerecha){
            Girar();
        }else if(direccionX < 0 && mirandoDerecha){
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

    private void Saltar()
    {
        if (enSuelo)
        {
        rb2D.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}