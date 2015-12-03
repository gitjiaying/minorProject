using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	//Player Appearrance
	public static int playerhair;
	public static int playerface;
	public static int playershirt;
	public static int playerpants;
	public static Color32 playerskinColor;
	public static int playerstamina;
	public static int playerhealth;

	//Characters Appearance
	public static int h1;
	public static int f1;
	public static int s1;
	public static int p1;
	public static Color32 sc1;

	public static int h2;
	public static int f2;
	public static int s2;
	public static int p2;
	public static Color32 sc2;

	public static int h3;
	public static int f3;
	public static int s3;
	public static int p3;
	public static Color32 sc3;

	public static int h4;
	public static int f4;
	public static int s4;
	public static int p4;
	public static Color32 sc4;

	public static int h5;
	public static int f5;
	public static int s5;
	public static int p5;
	public static Color32 sc5;

	public static int h6;
	public static int f6;
	public static int s6;
	public static int p6;
	public static Color32 sc6;

	//Settings
	public static bool soundEffects;
	public static bool thirdPerson;
	public static bool music;

	private static bool created = false;


	
	void Awake() {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		} 
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerhair);
		Debug.Log (playerface);
	}



}
