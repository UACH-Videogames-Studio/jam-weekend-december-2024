using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUpPlatform : MonoBehaviour
{
    public GameObject linkedObject;  // Objeto que se moverá hacia arriba
    public float moveDownDistance = 1f; // Distancia que el PushUpObject se moverá hacia abajo
    public float moveUpDistance = 4f;   // Distancia que el linkedObject se moverá hacia arriba
    public float moveSpeed = 2f;        // Velocidad del movimiento

    private bool isMoving = false;  // Controla si el movimiento está en curso
    private Vector3 initialPositionPush; // Guarda la posición inicial del objeto con el que se colisiona
    private Vector3 initialPositionLinked; // Guarda la posición inicial del objeto vinculado
    private Vector3 targetPositionDown; // Posición objetivo hacia abajo
    private Vector3 targetPositionUp;   // Posición objetivo hacia arriba para el objeto vinculado

    void Start()
    {
        // Inicializa las posiciones originales de los objetos
        if (linkedObject != null)
        {
            initialPositionLinked = linkedObject.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PushUpObject") && !isMoving)
        {
            // Configurar las posiciones iniciales y finales
            initialPositionPush = collision.gameObject.transform.position;
            targetPositionDown = initialPositionPush + Vector3.down * moveDownDistance;

            if (linkedObject != null)
            {
                targetPositionUp = initialPositionLinked + Vector3.up * moveUpDistance;
            }

            // Inicia el movimiento hacia las posiciones objetivo
            StartCoroutine(MoveObjects(collision.gameObject, targetPositionDown, targetPositionUp));
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PushUpObject") && !isMoving)
        {
            // Regresa los objetos a sus posiciones originales
            StartCoroutine(MoveObjects(collision.gameObject, initialPositionPush, initialPositionLinked));
        }
    }

    IEnumerator MoveObjects(GameObject pushObject, Vector3 pushTarget, Vector3 linkedTarget)
    {
        isMoving = true;

        // Movimiento simultáneo
        while (Vector3.Distance(pushObject.transform.position, pushTarget) > 0.01f)
        {
            // Mover el objeto con el que se colisionó
            pushObject.transform.position = Vector3.MoveTowards(pushObject.transform.position, pushTarget, moveSpeed * Time.deltaTime);

            // Mover el objeto vinculado si está configurado
            if (linkedObject != null)
            {
                linkedObject.transform.position = Vector3.MoveTowards(linkedObject.transform.position, linkedTarget, moveSpeed * Time.deltaTime);
            }

            yield return null; // Espera un frame antes de continuar
        }

        // Asegurar que las posiciones finales se alcancen
        pushObject.transform.position = pushTarget;
        if (linkedObject != null)
        {
            linkedObject.transform.position = linkedTarget;
        }

        isMoving = false;
    }
}
