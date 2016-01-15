﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public int damagePerHit = 100;
    public float timeBetweenAttacks = 0.5f;
    bool hit = false;

    float timer;
    private NerdsHealth nerdsHealth;


	
	
	void Update ()
    {
        timer += Time.deltaTime;
	}

 

    void OnTriggerStay (Collider col)
    {

        if (col.gameObject.tag == "Nerd" && Input.GetKeyDown("mouse 0") && timer > timeBetweenAttacks)
        {
			nerdsHealth=col.gameObject.GetComponent<NerdsHealth>();
            nerdsHealth.TakeDamage(damagePerHit);
            timer = 0f;
            Debug.Log("HIT");

        }
        
    }

    

}
