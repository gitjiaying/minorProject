using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{

    AudioSource source;
    bool dead = false;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.clip = ((AudioClip)Resources.Load("Music/GameMusic"));
        source.loop = true;
        source.Play();

    }

    void Update()
    {

        if (!GameManagerScript.alive && !dead)
        {
            source.Stop();
            source.PlayOneShot((AudioClip)Resources.Load("Music/GameOver"));
            dead = true;
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
