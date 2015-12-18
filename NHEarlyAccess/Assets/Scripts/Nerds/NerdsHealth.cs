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
	
	void Awake ()
    {
        currentHealth = startingHealth;
		anim = GetComponent<Animator>();
	}

	void Update ()
    {
		if (isSinking) {
			transform.Translate(new Vector3(0,0,1)*sinkSpeed*Time.deltaTime);
		}
	}

	void FixedUpdate(){
		Animating ();
	}

    public void TakeDamage(int amount)
    {
        Debug.Log("Damage");
        if (!GameManagerScript.alive)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
		isDead = true;
		GetComponent<FollowShortestPath> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = false;
		GetComponent<Rigidbody> ().AddForce(-5000*transform.eulerAngles.normalized);
		Invoke ("sink", 2);
		Destroy (gameObject, 5f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Book")
        {
            TakeDamage(damagePerBook);
            Debug.Log("HIT");
        }
		if (col.gameObject.tag == "Geo") {
			TakeDamage (damagePerGeo);
		}
    }

	void sink(){
		isSinking = true;
		GetComponent<Rigidbody> ().isKinematic = true;
	}

	void Animating(){
		bool dead = currentHealth < 0;
		anim.SetBool ("Dead", dead);
	}

}
