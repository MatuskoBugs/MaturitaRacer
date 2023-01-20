using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseM : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUi;

    public GameObject pauseFirst;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pauze();
            }
        
        }
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pauze()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirst);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GamePaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("RaceMenu");
        GamePaused = false;
    }
}
