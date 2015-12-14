using UnityEngine;
using System.Collections;

public class NerdsHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int damagePerBook = 40;

    bool isDead;
	
	void Awake ()
    {
        currentHealth = startingHealth;
	
	}

	void Update ()
    {

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

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Book")
        {
            TakeDamage(damagePerBook);
            Debug.Log("HIT");
        }
    }


}
