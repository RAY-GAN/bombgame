using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{


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
        gameObject.transform.GetChild(0).gameObject.SetActive(state == GameManager.GameState.Start);
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartgameOnClick()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Playing);
       
    }

    

}
