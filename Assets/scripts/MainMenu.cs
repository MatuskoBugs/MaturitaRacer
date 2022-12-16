using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RaceMenu()
    {
        SceneManager.LoadScene("RaceMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Akoze som sa vypol :)");
        Application.Quit();
    }
}
