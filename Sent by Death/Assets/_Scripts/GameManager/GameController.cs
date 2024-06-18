using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    Play, Pause
}
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameState gameState;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch(gameState)
        {
            case GameState.Play:
                Time.timeScale = 1.0f;
                break;

            case GameState.Pause:
                Time.timeScale = 0.0f;
                break;
        }
    }
    
}
