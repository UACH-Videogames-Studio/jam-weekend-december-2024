using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActorObject : MonoBehaviour
{
    //What do actor objects need?
    //List-----------------------
    //1. Input listener
    //   Need a input listener class to record inputs that are being executed.
    //2. Object Controller
    //   Read inputs and apply them to the object.
    //3. Recording System / Playback System
    //   Recording system will need to record inputs from the player and then be able to play it back to the object


    //1 
    private InputListener inputListener;

    //2
    private GhostMovement ghostMovement;

    //3
    private InputRecorder inputRecorder;

    public enum ActorState
    {
        PLAYING,
        PLAYBACK,
        RESET

    }
    public ActorState currentState;


    //Booleans to check initial state changes
    private bool newPlayback = false;
    private float timer;
    private float playbackTimer;

    //UI Timer
    // public TextMeshPro timerText;
    // Start is called before the first frame update
    void Start()
    {
        //initialize the variables
        inputListener = GetComponent<InputListener>();
        ghostMovement = GetComponent<GhostMovement>();
        inputRecorder = GetComponent<InputRecorder>();
        //Player starts as idle until their clicked on, prob change this later
        currentState = ActorState.RESET;
        timer = 0;
        playbackTimer = 0;
    }

    // Update is called once per frame
    // For button presses I noticed that if they're listened for in the fixed update they are somtimes missed
    // With this listening in a normal update loop, the button press is set to true. Then when the fixed update
    // goes over it, it will record the value as true, and then clear it for the next time the button is true.

    public void FixedUpdate()
    {

        if (currentState == ActorState.PLAYING)
        {
            timer = timer + Time.deltaTime;
            // timerText.text = timer.ToString("F2");
            inputListener.GetInputs();
            InputObject inputObject = inputListener.GetInputObject();
            inputRecorder.AddToDictionary(timer, inputObject);
            ghostMovement.GivenInputs(inputObject);
            inputListener.ResetInput();
        }

        if (currentState == ActorState.PLAYBACK)
        {
            if (newPlayback == true)
            {
                playbackTimer = 0;
                newPlayback = false;
            }

            playbackTimer = playbackTimer + Time.deltaTime;
            // timerText.text = playbackTimer.ToString("F2");
            if (inputRecorder.DoesKeyExist(playbackTimer))
            {
                InputObject recordedInputs = inputRecorder.GetRecordedInputs(playbackTimer);
                ghostMovement.GivenInputs(recordedInputs);
            }

        }

        if ((int)currentState == 2)
        {
            timer = 0;
            // timerText.text = "0.00";
        }
    }

    public void Recording()
    {
        timer = 0;
        inputRecorder.ClearHistory();
        currentState = ActorState.PLAYING;
    }


    public void Playback()
    {
        newPlayback = true;
        currentState = ActorState.PLAYBACK;
    }

    public void Reset()
    {
        ghostMovement.Reset();
        currentState = ActorState.RESET;
        inputListener.ResetInput();
    }
}
