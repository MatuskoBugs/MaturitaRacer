using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameStates {beforeRace, race, raceOver};

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    GameStates gameState = GameStates.beforeRace;

    float raceStartedTime = 0;
    float raceOverTime = 0;

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

    public float GetRaceTime()
    {
        if (gameState == GameStates.raceOver)
        { return raceOverTime - raceStartedTime; }
        else
        { return Time.time - raceStartedTime; }
    }

    void LevelStart()
    {
        gameState = GameStates.beforeRace;
    }

    public void RaceStart()
    {
        raceStartedTime = Time.time;

        ChangeGameState(GameStates.race);
    }

    public void RaceOver()
    {
        raceOverTime = Time.time;

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
