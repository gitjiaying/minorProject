using UnityEngine;
using System.Collections;

public class NerdsHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    bool isDead;
	
	void Awake ()
    {
        currentHealth = startingHealth;
	
	}

	void Update ()
    {

	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
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


}
