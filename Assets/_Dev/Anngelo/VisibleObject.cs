using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleObject : MonoBehaviour
{
    public GameObject objectToVisible;

    void Start()
    {
        objectToVisible.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            objectToVisible.gameObject.SetActive(true);
        }
    }
}
