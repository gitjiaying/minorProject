using UnityEngine;
using System.Collections;

public class NerdInitiator : MonoBehaviour {

    public NerdsHealth health;
    public FollowShortestPath follow;
    public float healthRate;
    public float speedRate;


	
	void Start ()
    {
        int averageHealth = Mathf.RoundToInt(100f + healthRate * GameScene.counter);
        health.startingHealth = averageHealth;

        int averageSpeed = Mathf.RoundToInt(6f + speedRate * GameScene.counter);
        follow.speed = Random.Range(averageSpeed - 1, averageSpeed + 1);
	}
	


}
