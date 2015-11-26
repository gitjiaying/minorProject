using UnityEngine;
using System.Collections;

public class CharAppearance : MonoBehaviour {

	public int index;
	public int hair;
	public int face;
	public int shirt;
	public int pants;
	public Color32 skinColor;
	public int stamina;
	public int health;
	//public GameObject unit;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer>().material.color = skinColor;
	}

	public void setAppearance(){

		GameManagerScript.playerhair = hair;
		GameManagerScript.playerface = face;
		GameManagerScript.playershirt = shirt;
		GameManagerScript.playerpants = pants;
		GameManagerScript.playerskinColor = skinColor;
		Debug.Log ("set appearance");
	}
}
