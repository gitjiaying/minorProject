﻿using UnityEngine;
using System.Collections;

public class NerdsHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public int damagePerBook = 40;
    public float sinkSpeed = 2.5f;
    public int damagePerGeo = 10;
    bool isSinking;
    bool isDead;
    Animator anim;
    private float spawn;
    private float timer;
    public float timeBetweenAttacks = 0.5f;
    ParticleSystem hitParticles;
	public int blastRadius;
	public int layer;
	public LayerMask mask;
    public bool isNormalNerd = true;

	private AudioSource source;

    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spawn = Time.time;
        hitParticles = GetComponentInChildren<ParticleSystem>();
		layer = 12;
		mask = 1 << layer;
		source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isSinking)
        {//sink dead nerd down thorugh the ground
            transform.Translate(new Vector3(0, -1, 0) * sinkSpeed * Time.deltaTime, Space.World);
        }
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Animating();
    }

    public void TakeDamage(int amount)//remove an amount of health from nerd
    {
        if (isDead)
            return;
        currentHealth -= amount;
        hitParticles.Play();

        Debug.Log("lost health");
        if (currentHealth <= 0)
        {
            Death(amount);
        }
    }

    void Death(int amount) //When a nerd dies, i tfalls over and score is increased depending on how the nerd died
    {
        Debug.Log("is no more");
        isDead = true;
        GetComponent<FollowShortestPath>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(-800 * transform.eulerAngles.normalized, ForceMode.Impulse);
        Invoke("sink", 2);
        Destroy(gameObject, 5f);
        GameManagerScript.nerdsKilled++;
        GameManagerScript.nerdsAverageLife = (GameManagerScript.nerdsAverageLife * (GameManagerScript.nerdsKilled - 1) + (Time.time - spawn)) / GameManagerScript.nerdsKilled;

        if (amount == 40)
        {
            GameManagerScript.score += 10;
            GameManagerScript.killedByBook++;
        }
        if (amount == 25)
        {
            GameManagerScript.score += 20;
            GameManagerScript.killedByGeo++;
        }
        if (amount == 100)
        {
            GameManagerScript.score += 50;
            GameManagerScript.killedByMelee++;
        }

        if (isNormalNerd)
        {
            GameManagerScript.score += 20;
            Debug.Log("nerd died!!" + GameManagerScript.score);
        }
        else
        {
            GameManagerScript.score += 400;
            Debug.Log("Ubernerd died!!" + GameManagerScript.score);
        }
        
    }

    void OnTriggerEnter(Collider col)//Deals different amounts of damage based on what hits the nerd
    {
        if (!isDead)
		{
			if (col.gameObject.tag == "Book") {
				
				if (GameManagerScript.bookEx) {
                    Instantiate(Resources.Load("Explosion"), col.transform.position, Quaternion.identity);
					source.PlayOneShot((AudioClip)Resources.Load("Music/Effects/Explosion"));
					Collider[] hitNerds = Physics.OverlapSphere (col.transform.position, blastRadius,mask);//deals damage to surrounding nerds when books are exploding
					int i = 0;
					Debug.Log (hitNerds.Length);
					while (i < hitNerds.Length) {
						hitNerds [i].gameObject.SendMessageUpwards ("AddBlastDamage");
						i++;
					}
                    TakeDamage(100);
					col.gameObject.SetActive (false);
				} else {
					TakeDamage (damagePerBook);
					Debug.Log ("HIT");
					GameManagerScript.booksHit++;
				}
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
			}
            if (col.gameObject.tag == "Geo")
            {
                TakeDamage(damagePerGeo);
                GameManagerScript.geoHit++;
                Debug.Log(GameManagerScript.geoHit + " " + GameManagerScript.geoThrown);
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown("mouse 1") && timer > timeBetweenAttacks)
        {
            TakeDamage(100);
            timer = 0f;
        }
    }

    void sink()
    {
        isSinking = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Animating()
    {
        anim.SetBool("Dead", isDead);
    }
	void AddBlastDamage(){
		TakeDamage (damagePerBook / 2);
	}

    public void setUberNerd(bool nerd)
    {
       isNormalNerd = nerd;
    }

}
