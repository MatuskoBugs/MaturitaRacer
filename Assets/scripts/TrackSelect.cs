using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSelect : MonoBehaviour
{
    public void Rally1()
    {
        SceneManager.LoadScene("Rally1P");
    }
    public void Rally2()
    {
        SceneManager.LoadScene("Rally2P");
    }
    public void Rally3()
    {
        SceneManager.LoadScene("Rally3P");
    }
    public void Rally4()
    {
        SceneManager.LoadScene("Rally4P");
    }
    public void Park1()
    {
        SceneManager.LoadScene("Park1P");
    }
    public void Park2()
    {
        SceneManager.LoadScene("Park2P");
    }
    public void Park3()
    {
        SceneManager.LoadScene("Park3P");
    }
    public void Park4()
    {
        SceneManager.LoadScene("Park4P");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

}
