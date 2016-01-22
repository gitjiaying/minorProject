﻿using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
	public AudioListener listen;
	public AudioListener listenfp;
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

		listen.enabled = GameManagerScript.music;
		listenfp.enabled = GameManagerScript.music;
    }
}
