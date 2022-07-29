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

    public float settime = 100f;
    public float bombtime = 10f;

    public PlayerInventory player1data;
    public PlayerInventory player2data;

    public Ball ball;

    public bool started = false; //从商店回来用

    public GameState State;

    public GameObject player1;
    public GameObject player2;



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
                HandleStartState();
                break;
            case GameState.Playing:
                HandlePlayingState(); 
                break;
            case GameState.Storeplayer1:
                break;
            case GameState.Storeplayer2:
                break;
            case GameState.Result:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);

    }


    private void HandleStartState()
    {
        player1data.itemlist.Clear();
        player1data.gold = 0;
        player1data.score = 0;
        player2data.itemlist.Clear();
        player2data.gold = 0;
        player2data.score = 0;

        started = false;
    }


    private void HandlePlayingState()
    {

   


        if (started == false)
        {

            bombtimer = Timer.createTimer("Bombtimer");
            bombtimer.startTiming(bombtime, OnbombComplete);

            gametimer = Timer.createTimer("Gametimer");
            gametimer.startTiming(settime, OngameComplete);

        }

        if (started == true)
        {
            
            //Debug.Log(gametimer.GetLeftTime());
            bombtimer = Timer.createTimer("Bombtimer");
            bombtimer.startTiming(bombtime, OnbombComplete);
            gametimer.connitueTimer();
            //Debug.Log("zhadanxianzai" + bombtimer.GetLeftTime());
        }

        started = true;
    }


    


    void OnbombComplete()
    {
        Debug.Log("booom!");
        if (ball.ballowner == 1)
        {
            player2data.score++;
            player1data.gold += 5;

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            Vector3 p1pos = player1.transform.position;
            Player player1script = player1.GetComponent<Player>();
       
            player1script.isTurn = false;
            ball.transform.position = new Vector3(p1pos.x, p1pos.y + 1.1f, p1pos.z);
            ball.transform.SetParent(player1.transform);
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints = RigidbodyConstraints2D.None;

            ball.ballowner = 2;
            ball.attackowner = 1;

            UpdateGameState(GameState.Storeplayer1);
        }

        if (ball.ballowner == 2)
        {
            player1data.score++;
            player2data.gold += 5;

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            Vector3 p2pos = player2.transform.position;
            Player player2script = player2.GetComponent<Player>();


            player2script.isTurn = false;


            ball.transform.position = new Vector3(p2pos.x, p2pos.y + 1.1f, p2pos.z);
            ball.transform.SetParent(player2.transform);
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints = RigidbodyConstraints2D.None;

            ball.ballowner = 1;
            ball.attackowner = 2;


            UpdateGameState(GameState.Storeplayer2);
        }

        gametimer.pauseTimer();
        Debug.Log(gametimer.GetLeftTime());

    }

   

    void OngameComplete()
    {
        Debug.Log("set complete!");
        UpdateGameState(GameState.Result);
    }

    

    public enum GameState
    {
        Start,
        Playing,
        Storeplayer1,
        Storeplayer2,
        Result,
    }
}
