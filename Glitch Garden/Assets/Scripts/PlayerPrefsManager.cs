using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Master volume out of range.");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Trying to unlock a level not in build order.");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
        }
        else
        {
            Debug.LogError("Trying to get the unlock status from a level not in build order.");
            return false;
        }
    }

    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.Log("Difficulty level out of range.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
