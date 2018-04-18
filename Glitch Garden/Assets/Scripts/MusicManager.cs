using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex < levelMusicChangeArray.Length)
        {
            AudioClip newClip = levelMusicChangeArray[scene.buildIndex];
            if (newClip && newClip != audioSource.clip)
            {
                audioSource.clip = newClip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
