using UnityEngine;
using System.Collections;

public class NerdsAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject player;
    PlayerHealth playerHealth;
    NerdsHealth nerdsHealth;
    bool playerInRange;
    float timer;


	void Awake (){

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        nerdsHealth = GetComponent<NerdsHealth>();
	}
	
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
   

    void Update () {

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
