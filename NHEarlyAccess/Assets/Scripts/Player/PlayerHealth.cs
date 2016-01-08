﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public PlayerController playerController;
    public int startingHealth = 100;
    public float currentHealth;
    public Slider healthSlider;

    
    bool isDead = false;
    bool damaged;
    ParticleSystem hitParticles;

    void Awake () {

        currentHealth = startingHealth;
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }
	
	void Start()
    {
        playerController = playerController.GetComponent<PlayerController>();
    }

    public void TakeDamage (float amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        hitParticles.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death ()
    {
        isDead = true;
        playerController.enabled = false;
		GameManagerScript.scores.Add(GameManagerScript.score);
		GameManagerScript.alive = false;
    }
}
