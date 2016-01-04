using UnityEngine;
using System.Collections;

public class PlayerAppearance: MonoBehaviour {
	
	// Use this for initialization
	private Material [] temp;
	public GameObject player;

	void Start () {
	
	}

	void Update () {
		rendertextures ();
	}

	void rendertextures(){
		temp = player.GetComponent<Renderer>().materials;
		for (int i=0; i<temp.Length; i++) {
			temp [i].SetColor ("_Color",(Color)GameManagerScript.playerskinColor);
		}
		player.GetComponent<Renderer>().materials = temp;
	}
}
