using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Home,
        GameRunning,
        Paused,
        GameEnd
    }

    private GameState currentGameState = GameState.Home;

    public GameState CurrentGameState
    {
        get { return currentGameState; }
        private set
        {
            if (currentGameState != value)
            {
                currentGameState = value;
                OnGameStateChanged?.Invoke(currentGameState);
            }
        }
    }

    public Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeGameState(GameState.Home);
    }

    public void ChangeGameState(GameState newState)
    {
        CurrentGameState = newState;

        switch (newState)
        {
            case GameState.Home:
                // Handle Home state
                break;
            case GameState.GameRunning:
                // Handle GameRunning state
                break;
            case GameState.Paused:
                // Handle Paused state
                break;
            case GameState.GameEnd:
                // Handle GameEnd state
                break;
        }
    }

    public void StartGame()
    {
        ChangeGameState(GameState.GameRunning);
    }

    public void PauseGame()
    {
        ChangeGameState(GameState.Paused);
    }

    public void EndGame()
    {
        ChangeGameState(GameState.GameEnd);
    }
}
