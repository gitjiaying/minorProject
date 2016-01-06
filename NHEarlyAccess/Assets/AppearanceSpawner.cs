using UnityEngine;
using System.Collections;

public class AppearanceSpawner : MonoBehaviour {

	public Renderer rend;
	private Material [] temp;
	private int randHair;
	private int randFace;
	private int randShirt;
	private int randPants;
	// Use this for initialization
	void Start () {
		randHair = Random.Range (1, 4);
		randFace = Random.Range (1, 4);
		randShirt = Random.Range (1, 4);
		randPants = Random.Range (1, 4);
		renderNerd ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void renderNerd(){
		//0=legs
		//1=feet
		//2=arms
		//3=face
		//4=hair
		//5=body
		temp = rend.materials;
		temp [3].SetTexture("_MainTex",Resources.Load("Characters/NerdFace"+ randFace, typeof(Texture))as Texture);
		temp [5] = Resources.Load ("Characters/NerdBody" + randShirt, typeof(Material))as Material ;
		temp [2] = Resources.Load ("Characters/NerdArm" + randShirt, typeof(Material))as Material ;
		temp [4] = Resources.Load ("Characters/NerdHair" + randHair, typeof(Material))as Material;
		temp [0] = Resources.Load ("Characters/Legs" + randPants, typeof(Material))as Material;
		
		this.rend.materials = temp;
	}
}
