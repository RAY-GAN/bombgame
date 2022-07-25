using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public static event Action<GameState> OnGameStateChanged;

    public  Timer bombtimer;
    public  Timer gametimer;

    public GameState State;
    

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Start);   
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Start:
                break;
            case GameState.Playing:
                HandlePlayingState(); 
                break;
            case GameState.Store:
                break;
            case GameState.Result:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);

    }


    private void HandlePlayingState()
    {
        bombtimer = Timer.createTimer("Bombtimer");
        bombtimer.startTiming(30, OnbombComplete, OnbombProcess);

        gametimer = Timer.createTimer("Gametimer");
        gametimer.startTiming(100, OngameComplete, OngameProcess);
    }


    


    void OnbombComplete()
    {
        Debug.Log("booom!");
        UpdateGameState(GameState.Store);
    }

    void OnbombProcess(float p)
    {
        //Debug.Log("on process" + p);
    }

    void OngameComplete()
    {
        Debug.Log("set complete!");
        UpdateGameState(GameState.Result);
    }

    static void OngameProcess(float p)
    {
        //Debug.Log("on process" + p);
    }

    public enum GameState
    {
        Start,
        Playing,
        Store,
        Result,
    }
}
