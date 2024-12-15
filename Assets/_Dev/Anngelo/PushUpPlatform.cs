using System.Collections;
using UnityEngine;

public class PushUpPlatform : MonoBehaviour
{
    public GameObject objectToPushup;
    public float moveDownDistance = 0.5f; // Distancia que el PushUpObject se moverá hacia abajo
    public float moveUpDistance = 4f;    // Distancia que el linkedObject se moverá hacia arriba
    public float moveSpeed = 0.5f;

    private bool isColliding = false;
    private Vector3 initialPositionPush; // Posición inicial del PushUpObject
    private Vector3 initialPositionLinked; // Posición inicial del linkedObject
    private Vector3 targetPositionDown;  // Posición objetivo hacia abajo
    private Vector3 targetPositionUp;    // Posición objetivo hacia arriba para el linkedObject
    private Coroutine pushCoroutine;     // Corutina para manejar PushUpObject
    private Coroutine linkedCoroutine;   // Corutina para manejar linkedObject

    private void Start()
    {
        // Inicializar posiciones originales
        if (objectToPushup != null)
        {
            initialPositionLinked = objectToPushup.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PushUpObject"))
        {
            isColliding = true; // Activar colisión
            initialPositionPush = collision.transform.position;
            targetPositionDown = initialPositionPush + Vector3.down * moveDownDistance;

            if (objectToPushup != null)
            {
                targetPositionUp = initialPositionLinked + Vector3.up * moveUpDistance;

                // Detener cualquier movimiento anterior y empezar uno nuevo para linkedObject
                if (linkedCoroutine != null)
                {
                    StopCoroutine(linkedCoroutine);
                }
                linkedCoroutine = StartCoroutine(SmoothMove(objectToPushup, targetPositionUp));
            }

            // Detener cualquier movimiento anterior y empezar uno nuevo para PushUpObject
            if (pushCoroutine != null)
            {
                StopCoroutine(pushCoroutine);
            }
            pushCoroutine = StartCoroutine(SmoothMove(collision.gameObject, targetPositionDown));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PushUpObject"))
        {
            isColliding = false; // Desactivar colisión
            if (objectToPushup != null)
            {
                targetPositionUp = initialPositionLinked; // Regresar a posición original si no hay colisión

                // Detener cualquier movimiento en curso
                if (linkedCoroutine != null)
                {
                    StopCoroutine(linkedCoroutine);
                }
                linkedCoroutine = StartCoroutine(SmoothMove(objectToPushup, initialPositionLinked));
            }

            if (pushCoroutine != null)
            {
                StopCoroutine(pushCoroutine);
            }
            pushCoroutine = StartCoroutine(SmoothMove(collision.gameObject, initialPositionPush));
        }
    }

    private IEnumerator SmoothMove(GameObject obj, Vector3 target)
    {
        while (Vector3.Distance(obj.transform.position, target) > 0.01f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, target, moveSpeed * Time.deltaTime);
            yield return null; // Esperar un frame
        }

        obj.transform.position = target; // Asegurar posición exacta al finalizar
    }
}
