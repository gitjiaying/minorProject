using UnityEngine;
using System.Collections;

public class NerdsAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public float attackDamage = 10f;

    GameObject player;
    PlayerHealth playerHealth;
    NerdsHealth nerdsHealth;
    bool playerInRange;
    float timer;
    GameObject nerd;

	void Awake (){
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        nerdsHealth = GetComponent<NerdsHealth>();
        nerd = GameObject.FindGameObjectWithTag("Nerd");
	}
	
    void OnTriggerEnter (Collider other)//check if touching player
    {
        if (other.gameObject == player)
        {
            Debug.Log("Enter");

            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Exit");

            playerInRange = false;
        }
    }


    void Update ()//If touching nerd will attack with frequency "timebetweenattacks"
    { 
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && nerdsHealth.currentHealth > 0)
        {
            Attack();
        }
	}

    void Attack ()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
