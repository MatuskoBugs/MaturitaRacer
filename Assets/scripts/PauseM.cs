using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseM : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
