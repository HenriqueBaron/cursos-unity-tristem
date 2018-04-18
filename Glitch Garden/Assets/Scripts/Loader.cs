using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 2)
        {
            LevelManager levelManager = gameObject.AddComponent<LevelManager>();
            levelManager.LoadNextLevel();
        }
    }
}
