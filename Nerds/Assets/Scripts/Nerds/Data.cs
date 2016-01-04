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
	
	//private File input;
	//private File output;
	
	
	void Start()
	{
		System.Console.WriteLine("StartAjdin");

	//	if (!File.Exists("inputs"))
     //   {
     //   	input = File.CreateText("inputs");
     //   }
     //   if (!File.Exists("outputs"))
     //   {
     //   	output = File.CreateText("outputs");
     //   }

	}

	void FixedUpdate() 
	{

		float curMoveX = Enemy.transform.position.x - previousPositionX;
	    EnemySpeedX = curMoveX / Time.deltaTime;
	    previousPositionX = Enemy.transform.position.x;

	    float curMoveZ = Enemy.transform.position.z - previousPositionZ;
	    EnemySpeedZ = curMoveZ / Time.deltaTime;
	    previousPositionZ = Enemy.transform.position.z;

		
		//EnemySpeedX = Enemy.velocity.x;
		//EnemySpeedZ = Enemy.velocity.z;

		PlayerSpeedX = Player.velocity.x;
		PlayerSpeedZ = Player.velocity.z;

		

		//Debug.Log(i/FPSmultiplier);
		i++;

		if( ((float)i/FPSmultiplier) >= timeInBetween)
		{
			i = 0;

			//output.WriteLine(PlayerSpeedX + " " + PlayerSpeedZ);
			System.IO.File.AppendAllText("C://Users//Ajdin//Downloads//UnitySpace//minorProject//Nerd//Nerds//Assets//Scenes//output2.txt", PlayerSpeedX + " " + PlayerSpeedZ + "\r\n");
			System.IO.File.AppendAllText("C://Users//Ajdin//Downloads//UnitySpace//minorProject//Nerd//Nerds//Assets//Scenes//input2.txt", EnemySpeedX + " " + EnemySpeedZ + "\r\n");
					//System.Console.WriteLine("PlayerX: " + PlayerSpeedX);
					//System.Console.WriteLine("PlayerZ: " + PlayerSpeedZ);
					//System.Console.WriteLine("EnemyX: " + EnemySpeedX);
					//System.Console.WriteLine("EnemyZ: " + EnemySpeedZ);
		}

				
	}


}
