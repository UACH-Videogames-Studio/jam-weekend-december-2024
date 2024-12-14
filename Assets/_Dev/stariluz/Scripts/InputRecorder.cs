using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private Dictionary<float, InputObject> playerInputRecord;

    void Start()
    {
        //Intialize the queue that will be used to record inputs
        playerInputRecord = new Dictionary<float, InputObject>();
    }  

    /*
    Adds the timeStamp and playerInputs into the dictionary
    The timeStamp is the key
    The input object is the value of the key
    This function is used by the actorObject script as the dictionary is private
    */
    public void AddToDictionary(float time, InputObject inputs)
    {
        playerInputRecord.Add(time, inputs);
    }


    public void ClearHistory()
    {
        playerInputRecord = new Dictionary<float, InputObject>();
    }
    
    //Check if key exists
    public bool DoesKeyExist(float key)
    {
        return playerInputRecord.ContainsKey(key);
    }
    
    //Returns the inputStruct at current timeStamp(in)
    public InputObject GetRecordedInputs(float timeStamp)
    {
        return playerInputRecord[timeStamp];
    }
}