using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameStates {beforeRace, race, raceOver };

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    GameStates gameState = GameStates.beforeRace;

    public event Action<GameManager> OnGameStateChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void ChangeGameState(GameStates newGameState)
    {
        if (gameState != newGameState)
        {
            gameState = newGameState;

            OnGameStateChanged?.Invoke(this);
        }

    }

    void LevelStart()
    {
        gameState = GameStates.beforeRace;
    }

    public void RaceStart()
    {
        ChangeGameState(GameStates.race);
    }

    public void RaceOver()
    {
        ChangeGameState(GameStates.raceOver);
    }

    public GameStates GetGameState()
    {
        return gameState;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelStart();
    }
}
