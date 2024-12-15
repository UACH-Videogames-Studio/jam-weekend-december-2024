using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenGoal : MonoBehaviour
{
    public UnityEvent ghostReachesEvent;
    public UnityEvent playerReachesEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag.Equals("Ghost")){
        Debug.Log("Collision");
            ghostReachesEvent?.Invoke();
        }else if(collider.tag.Equals("Player")){
            playerReachesEvent?.Invoke();
        }
    }
}
