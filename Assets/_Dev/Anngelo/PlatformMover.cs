using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 2f;
    private bool movingToEnd = true;

    void Start()
    {
        transform.position = startPoint;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (movingToEnd)
        {
            // Mover hacia el punto especificado como final
            transform.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, endPoint) < 0.1f) //Ya llego al destino
                movingToEnd = false;  // Cambiar de direccion
        }
        else
        {
            // Mover hacia el punto especificado como inicio
            transform.position = Vector2.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPoint) < 0.1f) //Ya llego al destino
                movingToEnd = true;  // Cambiar de direccion
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Vuelve al player hijo de la plataforma para que se desplacen al mismo tiempo
            collision.transform.SetParent(this.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deja de ser hijo de la plataforma y se mueve independiente de nuevo
            collision.transform.SetParent(null);
        }
    }
}
