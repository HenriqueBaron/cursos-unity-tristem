using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
        }
        else
        {
            Debug.LogWarning("No music player found in Start Scene to set the volume.");
        }
    }

}
