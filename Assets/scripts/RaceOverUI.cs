using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceOverUI : MonoBehaviour
{

    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }

    void OnGameStateChanged(GameManager gameManager)
    {
        if (GameManager.instance.GetGameState() == GameStates.raceOver)
        {
            canvas.enabled = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnDestroy()
    {
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }
}
