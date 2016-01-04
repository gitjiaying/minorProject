using UnityEngine;
using System.Collections;

public class NerdsHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int damagePerBook = 40;
    public float sinkSpeed = 2.5f;

    Animator anim;
    bool isDead;
    bool isSinking;
	
	void Awake ()
    {
        currentHealth = startingHealth;

        anim = GetComponent<Animator>();
	
	}

	void Update ()
    {
        if (isSinking)
        {
            transform.Translate(new Vector3(0,0,-1) * sinkSpeed * Time.deltaTime);
        }
	}

    void FixedUpdate()
    {
        Animating();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Damage");
        if (isDead)
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

        GetComponent<FollowShortestPath>().enabled = false;
        Invoke("sink", 2);

        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Book")
        {
            TakeDamage(damagePerBook);
            Debug.Log("HIT");
        }
    }

    private void sink()
    {
        isSinking = true;
        GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("sink");
    }

    void Animating()
    {
        bool dead = currentHealth <= 0;
        anim.SetBool("Dead", dead);
    }

}
