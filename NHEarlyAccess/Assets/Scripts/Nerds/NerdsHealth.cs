using UnityEngine;
using System.Collections;

public class NerdsHealth : MonoBehaviour {

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
	void Awake ()
    {
        currentHealth = startingHealth;
		anim = GetComponent<Animator>();
		spawn = Time.time;
	}

	void Update ()
    {
		if (isSinking) {
			transform.Translate(new Vector3(0,-1,0)*sinkSpeed*Time.deltaTime,Space.World);
		}
		timer += Time.deltaTime;
	}

	void FixedUpdate(){
		Animating ();
	}

    public void TakeDamage(int amount)
    {
        Debug.Log("Damage");
        if (isDead)
            return;
		Debug.Log ("lost health");

        currentHealth -= amount;

		Debug.Log ("lost health");
        if (currentHealth <= 0)
        {
            Death(amount);
        }
    }

    void Death(int amount)
    {
		Debug.Log ("is no more");
		isDead = true;
		GetComponent<FollowShortestPath> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = false;
		GetComponent<Rigidbody> ().AddForce(-800*transform.eulerAngles.normalized,ForceMode.Impulse);
		Invoke ("sink", 2);
		Destroy (gameObject, 5f);
		GameManagerScript.nerdsKilled++;
		GameManagerScript.nerdsAverageLife = (GameManagerScript.nerdsAverageLife * (GameManagerScript.nerdsKilled - 1) + (Time.time - spawn)) / GameManagerScript.nerdsKilled;
    	
		if (amount == 40) {
			GameManagerScript.score+=40;
			GameManagerScript.killedByBook++;
		}
		if (amount ==10) {
			GameManagerScript.score+=50;
			GameManagerScript.killedByGeo++;
		}
		if (amount ==100) {
			GameManagerScript.score+=100;
			GameManagerScript.killedByMelee++;
		}
	}

    void OnTriggerEnter(Collider col)
    {
		if (!isDead) {
			if (col.gameObject.tag == "Book") {
				TakeDamage (damagePerBook);
				Debug.Log ("HIT");
				GameManagerScript.booksHit++;
			}
			if (col.gameObject.tag == "Geo") {
				TakeDamage (damagePerGeo);
				GameManagerScript.geoHit++;
			}
		}
    }
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Player" && Input.GetKeyDown("mouse 1") && timer > timeBetweenAttacks)
		{
			TakeDamage(100);
			timer = 0f;
			Debug.Log("HIT");
			
		}
		
	}

	void sink(){
		isSinking = true;
		GetComponent<Rigidbody> ().isKinematic = true;
	}

	void Animating(){
		anim.SetBool ("Dead", isDead);
	}

}
