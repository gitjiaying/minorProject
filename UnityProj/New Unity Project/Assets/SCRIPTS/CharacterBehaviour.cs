using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {

	public float moveZ; 
	public float moveX;
	private Vector3 moveVector;
	
	// Update is called once per frame
	void Update () 
	{
			moveX = Input.GetAxis ("Horizontal");
			moveZ = Input.GetAxis ("Vertical");
			moveVector = new Vector3 (moveX, 0.0f, moveZ);
	}
}
