using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionController : MonoBehaviour
{
    LeaderboardMain leaderboardMain;

    public List<CarLapCounter> carLapCounters = new List<CarLapCounter>();

    void Start()
    {
        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();

        carLapCounters = carLapCounterArray.ToList<CarLapCounter>();

        foreach (CarLapCounter lapCounters in carLapCounters)
        {
            lapCounters.OnPassCheckpoint += OnPassCheckpoint;
        }

        leaderboardMain = FindObjectOfType<LeaderboardMain>();

        if (leaderboardMain != null)
        {
            leaderboardMain.UpdateList(carLapCounters);
        }
    }

    void OnPassCheckpoint(CarLapCounter carlapcounter)
    {
        carLapCounters = carLapCounters.OrderByDescending(s => s.GetNumberOfCheckpointPassed()).ThenBy(s => s.GetTimeAtLastCheckpoint()).ToList();

        int carPosition = carLapCounters.IndexOf(carlapcounter) + 1;

        carlapcounter.SetCarPosition(carPosition);

        if (leaderboardMain != null)
        {
            leaderboardMain.UpdateList(carLapCounters);
        }
    }
}
