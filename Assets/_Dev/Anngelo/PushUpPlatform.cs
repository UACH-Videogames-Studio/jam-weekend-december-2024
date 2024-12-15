using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUpPlatform : MonoBehaviour
{
    public GameObject objectToPushUp;  //Gameobject a mover hacia arriba
    public float moveDistance = 1f; 
    public float moveSpeed = 2f;    

    private bool isMoving = false;  
    private Vector3 initialPosition; // Guarda la posición inicial del objeto que colisiona
    private Vector3 targetPositionDown; // Guarda la posición objetivo hacia abajo
    private Vector3 targetPositionUp; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PushUpObject") && !isMoving)
        {
            initialPosition = collision.gameObject.transform.position;
            targetPositionDown = initialPosition + Vector3.down * moveDistance;

            if (objectToPushUp != null)
            {
                targetPositionUp = objectToPushUp.transform.position + Vector3.up * moveDistance;
            }

            // Iniciar movimiento
            StartCoroutine(MoveObjects(collision.gameObject));
        }
    }

    IEnumerator MoveObjects(GameObject pushObject)
    {
        isMoving = true;

        // Movimiento simultáneo
        while (Vector3.Distance(pushObject.transform.position, targetPositionDown) > 0.01f)
        {
            // Mover el objeto con el tag "PushUpObject" hacia abajo
            pushObject.transform.position = Vector3.MoveTowards(pushObject.transform.position, targetPositionDown, moveSpeed * Time.deltaTime);

            // Mover el objeto vinculado hacia arriba si está configurado
            if (objectToPushUp != null)
            {
                objectToPushUp.transform.position = Vector3.MoveTowards(objectToPushUp.transform.position, targetPositionUp, moveSpeed * Time.deltaTime);
            }

            yield return null; // Espera un frame antes de continuar
        }

        // Asegurar que las posiciones finales se alcancen
        pushObject.transform.position = targetPositionDown;
        if (objectToPushUp != null)
        {
            objectToPushUp.transform.position = targetPositionUp;
        }

        isMoving = false;
    }
}
