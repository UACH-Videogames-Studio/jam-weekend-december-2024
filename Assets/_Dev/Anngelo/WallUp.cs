using System.Collections;
using UnityEngine;

public class WallUp : MonoBehaviour
{
    public GameObject wallToUp; // El objeto que se moverá
    public float speed = 1.5f; // Velocidad del movimiento
    public float distance = 5f; // Distancia total en el eje Y

    private bool isMoving = false; // Evita movimientos simultáneos
    private bool moveUp = true; // Alterna entre subir y bajar
    private Vector3 originalPosition; // Guarda la posición inicial

    void Start()
    {
        // Guarda la posición inicial al inicio del juego
        originalPosition = wallToUp.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && !isMoving)
        {
            // Alterna entre subir y regresar
            if (moveUp)
            {
                StartCoroutine(MoveWall(wallToUp.transform.position + new Vector3(0, distance, 0))); // Mover hacia arriba
            }
            else
            {
                StartCoroutine(MoveWall(originalPosition)); // Regresar a la posición inicial
            }

            moveUp = !moveUp; // Cambia el estado para el próximo movimiento
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && !isMoving)
        {
            // Alterna entre subir y regresar
            if (moveUp)
            {
                StartCoroutine(MoveWall(wallToUp.transform.position + new Vector3(0, -distance, 0))); // Mover hacia arriba
            }
            else
            {
                StartCoroutine(MoveWall(originalPosition)); // Regresar a la posición inicial
            }

            moveUp = !moveUp; // Cambia el estado para el próximo movimiento
        }
    }

    IEnumerator MoveWall(Vector3 targetPosition)
    {
        isMoving = true; // Bloquea movimientos simultáneos

        // Mientras la posición actual no sea aproximadamente igual al objetivo
        while (Vector3.Distance(wallToUp.transform.position, targetPosition) > 0.01f)
        {
            // Interpola suavemente hacia la posición objetivo
            wallToUp.transform.position = Vector3.MoveTowards(
                wallToUp.transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

            yield return null; // Espera al siguiente frame
        }

        // Ajusta la posición exactamente al objetivo para evitar imprecisiones
        wallToUp.transform.position = targetPosition;

        isMoving = false; // Permite otro movimiento
    }
}
