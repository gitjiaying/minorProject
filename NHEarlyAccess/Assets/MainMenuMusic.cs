using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour
{

    static bool AudioBegin = false;

    void Awake()
    {
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (Application.loadedLevelName == "Game")
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }

        if (GameManagerScript.music == false)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
        }
    }
}