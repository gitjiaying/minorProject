using UnityEngine;
using System.Collections;

public class PlayerAppearance: MonoBehaviour {
	
	// Use this for initialization
	private Material [] temp;
	public GameObject player;

	void Start () {
	
	}

	void Update () {
		renderCharacter ();
	}

	void renderCharacter(){
		//0=legs
		//1=feet
		//2=arms
		//3=face
		//4=hair
		//5=body
		temp = player.GetComponent<Renderer>().materials;
		temp [3].SetColor ("_Color",(Color)GameManagerScript.playerskinColor);
		temp [3].SetTexture("_MainTex",Resources.Load("Face"+ GameManagerScript.playerface, typeof(Texture))as Texture);
		temp [5] = Resources.Load ("Body" + GameManagerScript.playershirt, typeof(Material))as Material ;
		temp [2] = Resources.Load ("Arms" + GameManagerScript.playershirt, typeof(Material))as Material ;
		temp [4] = Resources.Load ("Hair" + GameManagerScript.playerhair, typeof(Material))as Material;
		temp [0] = Resources.Load ("Legs" + GameManagerScript.playerpants, typeof(Material))as Material;
		
		player.GetComponent<Renderer>().materials = temp;
	}
}

