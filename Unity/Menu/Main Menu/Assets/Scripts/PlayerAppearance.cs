using UnityEngine;
using System.Collections;

public class PlayerAppearance: MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		this.GetComponent<Renderer>().material.color = GameManagerScript.playerskinColor;

	}
}
