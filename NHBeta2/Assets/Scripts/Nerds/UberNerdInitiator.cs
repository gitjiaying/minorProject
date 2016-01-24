using UnityEngine;
using System.Collections;

public class UberNerdInitiator : MonoBehaviour {

    public NerdsHealth health;
    public FollowShortestPath follow;
    public float healthRate;
    public float speedRate;


	
	void Start ()//instatntiates an ubernerd with health and speeed based on a timer (counter)
    {
		int averageHealth = Mathf.RoundToInt(health.startingHealth + healthRate * GameScene.counter);
        health.currentHealth = averageHealth;

		int averageSpeed = Mathf.RoundToInt(follow.speed + speedRate * GameScene.counter);
        follow.speed = Random.Range(averageSpeed - 1, averageSpeed + 1);
	}
	


}
