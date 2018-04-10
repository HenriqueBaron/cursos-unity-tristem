using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int actualScore = 0;
    Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }

    public static void Reset()
    {
        actualScore = 0;
    }

    public void Score(int points)
    {
        actualScore += points;
        scoreText.text = actualScore.ToString();
    }
}
