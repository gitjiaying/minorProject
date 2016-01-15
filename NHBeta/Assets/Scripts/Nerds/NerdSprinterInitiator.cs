using UnityEngine;
using System.Collections;

public class NerdSprinterInitiator : MonoBehaviour {

    public NerdsHealth health;
    public FollowShortestPath follow;
    public float healthRate;
    public float speedRate;


	
	void Start ()
    {
        int averageHealth = Mathf.RoundToInt(80f + healthRate * GameScene.counter);
        health.startingHealth = averageHealth;

        int averageSpeed = Mathf.RoundToInt(12f + speedRate * GameScene.counter);
        follow.speed = Random.Range(averageSpeed - 1, averageSpeed + 1);
	}
	


}
