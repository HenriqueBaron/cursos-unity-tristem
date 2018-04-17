using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private static MusicPlayer player;
    private AudioSource music;

    /* Observação: a ordem de execução dos métodos é importante. Awake é chamado antes de Start. */

    void Awake()
    {
        if (player != null && player != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            player = this;
            DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
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
        Debug.Log("Music player loaded level " + scene.buildIndex);

        try
        {
            music.Stop();
        }
        catch { };

        switch (scene.buildIndex)
        {
            case 0:
                music.clip = startClip;
                break;

            case 1:
                music.clip = gameClip;
                break;

            case 2:
                music.clip = endClip;
                break;

            default:
                break;
        }

        music.loop = true;
        music.Play();
    }

}
