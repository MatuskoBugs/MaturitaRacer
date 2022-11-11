using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardMain : MonoBehaviour
{
    public GameObject leaderboardItem;

    LeaderboardItem[] setLeaderboardItem;

    Canvas canvas;

    bool isntialized = false;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }

    void Start()
    {
        VerticalLayoutGroup leaderboardLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>();

        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();

        setLeaderboardItem = new LeaderboardItem[carLapCounterArray.Length];

        for (int i = 0; i < carLapCounterArray.Length; i++)
        {
            GameObject LeaderboardGameObject = Instantiate(leaderboardItem, leaderboardLayoutGroup.transform);
            setLeaderboardItem[i] = LeaderboardGameObject.GetComponent<LeaderboardItem>();
            setLeaderboardItem[i].SetPositionText($"{i + 1}.");

        }

        isntialized = true;
    }

    public void UpdateList(List<CarLapCounter> lapCounters)
    {
        if (isntialized == false)
        { 
            return;
        }

        for (int i = 0; i < lapCounters.Count; i++)
        {
            setLeaderboardItem[i].SetCarName(lapCounters[i].gameObject.name);
        }
        
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
