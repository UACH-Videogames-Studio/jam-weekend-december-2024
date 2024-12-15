using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerController : MonoBehaviour
{
    public RecordingController recordingController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerChange(){
        recordingController.DisablePlayer();
        StartCoroutine(WaitChange(1));
    }

    public IEnumerator WaitChange(float seconds){
        // @todo show in screen an indicative of the change
        yield return new WaitForSeconds(seconds);
        recordingController.ResetPlayer();
        recordingController.StartPlayback();
    }
}
