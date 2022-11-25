using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class CarLapCounter : MonoBehaviour
{
    int PassedCheckpointNumber = 0;
    float TimeAtLastPassedCheckpoint = 0;
    int NumberOfPassedCheckpoints = 0;

    int LapsCompleted = 0;
    public int LapstoComplete = 5;
    bool RaceCompleted = false;

    int carPosition = 0;

    public event Action<CarLapCounter> OnPassCheckpoint;

    public TMPro.TextMeshProUGUI CarPosText;

    IEnumerator CarPosTextd(float delay)
    {
        CarPosText.text = carPosition.ToString();

        CarPosText.gameObject.SetActive(true);

        yield return new WaitForSeconds(delay);
        
        CarPosText.gameObject.SetActive(false);
    }

    public void SetCarPosition(int position)
    {
        carPosition = position;
    }

    public int GetCarPosition()
    {
        return carPosition;
    }

    public int GetNumberOfCheckpointPassed()
    {
        return NumberOfPassedCheckpoints;
    }

    public float GetTimeAtLastCheckpoint()
    {
        return TimeAtLastPassedCheckpoint;
    }

    private void OnTriggerEnter(Collider boxcollider)
    {
        if (boxcollider.CompareTag("Checkpoint"))
        {
            if (RaceCompleted)
            {
                return;
            }

            Checkpoint checkpoint = boxcollider.GetComponent<Checkpoint>();

            if (PassedCheckpointNumber + 1 == checkpoint.checkPointNumber)
            {
                PassedCheckpointNumber = checkpoint.checkPointNumber;

                NumberOfPassedCheckpoints++;

                TimeAtLastPassedCheckpoint = Time.time;

                if (checkpoint.FinishLine)
                {
                    PassedCheckpointNumber = 0;
                    LapsCompleted++;
                    if (LapsCompleted >= LapstoComplete)
                    {
                        RaceCompleted = true;
                    }
                }

                OnPassCheckpoint?.Invoke(this);

                StartCoroutine(CarPosTextd(999999));

                if (RaceCompleted)
                {
                    if (CompareTag("P1") || CompareTag("P2") || CompareTag("P3") || CompareTag("P4"))
                    {
                        GameManager.instance.RaceOver();
                        GetComponent<Inputhandler>().enabled = false;
                    }
                }

            }
        }
    }
}
