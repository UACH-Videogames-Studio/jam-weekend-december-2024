using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingController : MonoBehaviour
{
    public GameObject selectedPlayer;

    public void Start(){
        StartRecording();
    }
    public void StartRecording()
    {
        ResetPlayer();
        selectedPlayer.GetComponent<ActorObject>().Recording();
    }

    public void startPlayback()
    {
        ResetPlayer();
        selectedPlayer.GetComponent<ActorObject>().Playback();
    }

    public void ResetPlayer()
    {
        selectedPlayer.GetComponent<ActorObject>().Reset();
    }
}
