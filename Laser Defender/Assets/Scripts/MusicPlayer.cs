using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer player;

    /* Observação: a ordem de execução dos métodos é importante. Awake é chamado antes de Start. */

    void Awake()
    {
        if (player != null)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            player = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
