using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;
    private int timesHit;

    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= maxHits) Destroy(gameObject);
    }

    //TODO: Remove this method as soon as we can actually win.
    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
