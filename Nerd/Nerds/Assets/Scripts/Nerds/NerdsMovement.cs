using UnityEngine;
using System.Collections;

public class NerdsMovement : MonoBehaviour {

    Transform player;
    PlayerHealth playerHealth;
    NerdsHealth nerdHealth;
    NavMeshAgent nav;


	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        nerdHealth = GetComponent<NerdsHealth>();
        nav = GetComponent<NavMeshAgent>();
    
	
	}
	

	void Update () {

        if (nerdHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
	
	}
}
