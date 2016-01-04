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
	public GameObject player;
	private Material [] temp;


	//public GameObject unit;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

		renderCharacter();

		switch (index)
		{
		case 6:
			GameManagerScript.h6 = hair;
			GameManagerScript.f6 = face;
			GameManagerScript.s6 = shirt;
			GameManagerScript.p6 = pants;
			GameManagerScript.sc6 = skinColor;
			break;
		case 5:
			GameManagerScript.h5 = hair;
			GameManagerScript.f5 = face;
			GameManagerScript.s5 = shirt;
			GameManagerScript.p5 = pants;
			GameManagerScript.sc5 = skinColor;
			break;
		case 4:
			GameManagerScript.h4 = hair;
			GameManagerScript.f4 = face;
			GameManagerScript.s4 = shirt;
			GameManagerScript.p4 = pants;
			GameManagerScript.sc4 = skinColor;
			break;
		case 3:
			GameManagerScript.h3 = hair;
			GameManagerScript.f3 = face;
			GameManagerScript.s3 = shirt;
			GameManagerScript.p3 = pants;
			GameManagerScript.sc3 = skinColor;
			break;
		case 2:
			GameManagerScript.h2 = hair;
			GameManagerScript.f2 = face;
			GameManagerScript.s2 = shirt;
			GameManagerScript.p2 = pants;
			GameManagerScript.sc2 = skinColor;
			break;
		case 1:
			GameManagerScript.h1 = hair;
			GameManagerScript.f1 = face;
			GameManagerScript.s1 = shirt;
			GameManagerScript.p1 = pants;
			GameManagerScript.sc1 = skinColor;
			break;
		}
	}

	public void setAppearance(){

		GameManagerScript.playerhair = hair;
		GameManagerScript.playerface = face;
		GameManagerScript.playershirt = shirt;
		GameManagerScript.playerpants = pants;
		GameManagerScript.playerskinColor = skinColor;
		Debug.Log ("set appearance");
	}

	public void getAppearance(){
		switch (index)
		{
		case 6:
			hair = GameManagerScript.h6;
			face = GameManagerScript.f6;
			shirt = GameManagerScript.s6;
			pants = GameManagerScript.p6;
			skinColor = GameManagerScript.sc6;
			break;
		case 5:
			hair = GameManagerScript.h5;
			face = GameManagerScript.f5;
			shirt = GameManagerScript.s5;
			pants = GameManagerScript.p5;
			skinColor = GameManagerScript.sc5;
			break;
		case 4:
			hair = GameManagerScript.h4;
			face = GameManagerScript.f4;
			shirt = GameManagerScript.s4;
			pants = GameManagerScript.p4;
			skinColor = GameManagerScript.sc4;
			break;
		case 3:
			hair = GameManagerScript.h3;
			face = GameManagerScript.f3;
			shirt = GameManagerScript.s3;
			pants = GameManagerScript.p3;
			skinColor = GameManagerScript.sc3;
			break;
		case 2:
			hair = GameManagerScript.h2;
			face = GameManagerScript.f2;
			shirt = GameManagerScript.s2;
			pants = GameManagerScript.p2;
			skinColor = GameManagerScript.sc2;
			break;
		case 1:
			hair = GameManagerScript.h1;
			face = GameManagerScript.f1;
			shirt = GameManagerScript.s1;
			pants = GameManagerScript.p1;
			skinColor = GameManagerScript.sc1;
			break;
		}
	}
	void renderCharacter(){
		//0=legs
		//1=feet
		//2=arms
		//3=face
		//4=hair
		//5=body
		temp = player.GetComponent<Renderer>().materials;
		temp [3].SetColor ("_Color",(Color)skinColor);
		temp [3].SetTexture("_MainTex",Resources.Load("Characters/Face"+ face, typeof(Texture))as Texture);
		temp [5] = Resources.Load ("Characters/Body" + shirt, typeof(Material))as Material ;
		temp [2] = Resources.Load ("Characters/Arms" + shirt, typeof(Material))as Material ;
		temp [4] = Resources.Load ("Characters/Hair" + hair, typeof(Material))as Material;
		temp [0] = Resources.Load ("Characters/Legs" + pants, typeof(Material))as Material;

		player.GetComponent<Renderer>().materials = temp;
	}
}
