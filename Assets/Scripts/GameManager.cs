using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text uiPoints;

    private int points = 0;

    public void IncresePoints(int amount)
    {
        points += amount;
        uiPoints.text = points.ToString();
    }
}
