using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMPro.TextMeshProUGUI countdownText;

    private void Awake()
    {
        countdownText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownCO());
    }

    IEnumerator CountdownCO()
    {
        yield return new WaitForSeconds(0.3f);

        int counter = 3;

        while (true)
        {
            if (counter != 0)
            {
                countdownText.text = counter.ToString();
            }
            else 
            {
                countdownText.text = "GO!";
                GameManager.instance.RaceStart();
                break;
            }

            counter--;
            yield return new WaitForSeconds(1.0f);
        }
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
