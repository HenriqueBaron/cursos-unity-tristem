using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;

    private bool isBreakable;
    private int timesHit;
    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (tag == "Breakable")
        {
            isBreakable = true;
            breakableCount++;
        }
        timesHit = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable) HandleHits();
    }

    private void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            Destroy(gameObject);
            breakableCount--;
            levelManager.BrickDestroyed();
        }

        else LoadSprites();
    }

    private void LoadSprites()
    {
        if (hitSprites[timesHit - 1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
    }
}
