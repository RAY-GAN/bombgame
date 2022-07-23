using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publictimer : MonoBehaviour
{

    public Timer publictimer;
    


    // Start is called before the first frame update
    void Start()
    {
        publictimer = Timer.createTimer("Publictimer");
        publictimer.startTiming(30, OnComplete, OnProcess);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnComplete()
    {
        Debug.Log("complete!");
    }

    void OnProcess(float p)
    {
        //Debug.Log("on process" + p);
    }
}
