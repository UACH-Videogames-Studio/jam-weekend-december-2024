using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Configuración del Timer")]
    public float duration = 60f; // Tiempo inicial en segundos
    public UnityEvent onTimerComplete; // Evento llamado cuando el tiempo llega a 0

    public float timeRemaining { get; private set; } // Tiempo restante
    private bool isRunning = false;  // Indica si el timer está corriendo
    private bool isPaused = false;   // Indica si el timer está pausado

    public void OnTimeFinished()
    {
        Debug.Log("¡El tiempo ha terminado!");
    }

    
    /// Inicia o reinicia el timer.
    public void StartTimer()
    {
        timeRemaining = duration; // Reiniciar el tiempo
        isRunning = true;
        isPaused = false;
        Debug.Log("Tiempo.");
    }

    /// Detiene el timer y reinicia el tiempo.
    public void Stop()
    {
        isRunning = false;
        timeRemaining = duration;
        Debug.Log("Timer detenido y reiniciado.");
    }

    /// Pausa el timer.
    public void Pause()
    {
        if (isRunning && !isPaused)
        {
            isPaused = true;
            Debug.Log("Timer pausado.");
        }
    }


    /// Reanuda el timer después de una pausa.
    public void Resume()
    {
        if (isRunning && isPaused)
        {
            isPaused = false;
            Debug.Log("Timer reanudado.");
        }
    }

    void Update()
    {
        // Reducir el tiempo solo si está corriendo y no está pausado
        if (isRunning && !isPaused)
        {
            timeRemaining -= Time.deltaTime;

            // Revisar si el tiempo llegó a 0
            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                isRunning = false; // Detener el timer
                Debug.Log("¡Se acabó el tiempo!");
                onTimerComplete?.Invoke(); // Invocar el evento
            }
        }
    }


    /// Devuelve el tiempo restante.
    public float GetTimeRemaining()
    {
        return timeRemaining;
    }
}


