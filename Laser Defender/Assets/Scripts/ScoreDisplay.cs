﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = ScoreKeeper.actualScore.ToString();
        ScoreKeeper.Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
