using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {


	public Rigidbody Enemy;
	public Rigidbody Player;


	float EnemySpeedX;
	float EnemySpeedZ;

	float PlayerSpeedX;
	float PlayerSpeedZ;
	
	public float timeInBetween = 0.4f;

	int i = 0;
	int FPSmultiplier = 60;

	private float previousPositionX;
	private float previousPositionZ;
	
	void Start()
	{
		System.Console.WriteLine("StartAjdin");

	}

	void FixedUpdate() 
	{

		float curMoveX = Enemy.transform.position.x - previousPositionX;
	    EnemySpeedX = curMoveX / Time.deltaTime;
	    previousPositionX = Enemy.transform.position.x;

	    float curMoveZ = Enemy.transform.position.z - previousPositionZ;
	    EnemySpeedZ = curMoveZ / Time.deltaTime;
	    previousPositionZ = Enemy.transform.position.z;

		PlayerSpeedX = Player.velocity.x;
		PlayerSpeedZ = Player.velocity.z;

		i++;

		if( ((float)i/FPSmultiplier) >= timeInBetween)
		{
			i = 0;

			System.IO.File.AppendAllText("C://Users//Ajdin//Downloads//UnitySpace//minorProject//Nerd//Nerds//Assets//Scenes//output2.txt", PlayerSpeedX + " " + PlayerSpeedZ + "\r\n");
			System.IO.File.AppendAllText("C://Users//Ajdin//Downloads//UnitySpace//minorProject//Nerd//Nerds//Assets//Scenes//input2.txt", EnemySpeedX + " " + EnemySpeedZ + "\r\n");

		}	
	}
}
