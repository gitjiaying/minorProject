using UnityEngine;
using System.Collections;

public class NerdSprinterInitiator : MonoBehaviour {

    public NerdsHealth health;
    public FollowShortestPath follow;
    public float healthRate;
    public float speedRate;


	
	void Start ()
    {
		int averageHealth = Mathf.RoundToInt(health.startingHealth + healthRate * GameScene.counter);
        health.currentHealth = averageHealth;

        int averageSpeed = Mathf.RoundToInt(follow.speed + speedRate * GameScene.counter);
        follow.speed = Random.Range(averageSpeed - 1, averageSpeed + 1);
	}
	


}
