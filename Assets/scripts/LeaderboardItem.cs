using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardItem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI positionText;
    public TMPro.TextMeshProUGUI CarNameText;
 
    public void SetPositionText(string newPosition)
    {
        positionText.text = newPosition;
    }

    public void SetCarName(string newCarN)
    {
        CarNameText.text = newCarN;
    }
}
