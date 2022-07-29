using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultpanel : MonoBehaviour
{

    public Text result;
    public PlayerInventory player1;
    public PlayerInventory player2;


    void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(state == GameManager.GameState.Result);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.score < player2.score)
        {
            result.text = "player2 wins";
        }

        if (player1.score > player2.score)
        {
            result.text = "player2 wins";
        }

        if (player1.score == player2.score)
        {
            result.text = "it's a tie";
        }

    }

    public void NewgameOnClick()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Start);

    }
}
