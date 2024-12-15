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
}
