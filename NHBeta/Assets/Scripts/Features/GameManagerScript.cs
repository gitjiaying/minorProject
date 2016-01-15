using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class GameManagerScript : MonoBehaviour {
	private string ScoreUrl = "http://drproject.twi.tudelft.nl:8085/getScore";
	private string CharUrl = "http://drproject.twi.tudelft.nl:8085/getCharacters";
	private JsonData Scoreobj;
	private JsonData Charobj;

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
	public static bool pause;
	public static bool alive;

	public static bool geo=false;
	public static bool bookLauncher=false;
	public static bool bookEx;

	//Stats per game
	public static int booksFired;
	public static int booksHit;
	public static int geoThrown;
	public static int geoHit;
	public static int nerdsKilled;
	public static float nerdsAverageLife;
	public static float timeAlive;
	public static int score;
	public static int killedByBook;
	public static int killedByGeo;
	public static int killedByMelee;

	//Highscores
	public static List<int> scores=new List<int>();

	
	void Awake() {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		} 

		StartCoroutine (getScore ());
		Invoke ("sethighscores", 0.5f);

		StartCoroutine (getChar ());
		Invoke ("setChar", 0.5f);

		soundEffects = false;
		thirdPerson = true;
		music = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator getScore()
	{
		WWWForm dataParameters = new WWWForm();
		dataParameters.AddField("UserId", LoginScript.userID);
		WWW www = new WWW(ScoreUrl,dataParameters);
		yield return www;
		Debug.Log(www.text);

		Scoreobj = JsonMapper.ToObject(www.text);
	}
	private void sethighscores(){
		for(int i = 0; i < 5; i++){
			scores.Add((int)Scoreobj [i] ["HighScore"]);
		}
	}

	IEnumerator getChar()
	{
		WWWForm dataParameters = new WWWForm();
		dataParameters.AddField("UserId", LoginScript.userID);
		WWW www = new WWW(CharUrl,dataParameters);
		yield return www;
		Debug.Log(www.text);

		Charobj = JsonMapper.ToObject(www.text);

		for(int i = 0; i < 2; i++){

			Debug.Log (Charobj[i]["Hair"]);

		}
	}
	private void setChar(){
		//Characters Appearance
		h1 = (int)Charobj [0] ["Hair"];
		f1 = (int)Charobj [0] ["Face"];
		s1 = (int)Charobj [0] ["Shirt"];
		p1 = (int)Charobj [0] ["Pants"];
		sc1 = new Color32((byte)Charobj [0] ["SkinR"],(byte)Charobj [0] ["SkinG"],(byte)Charobj [0] ["SkinB"],1);

		h2 = (int)Charobj [1] ["Hair"];
		f2 = (int)Charobj [1] ["Face"];
		s2 = (int)Charobj [1] ["Shirt"];
		p2 = (int)Charobj [1] ["Pants"];
		sc2 = new Color32((byte)Charobj [1] ["SkinR"],(byte)Charobj [1] ["SkinG"],(byte)Charobj [1] ["SkinB"],1);

		h3 = (int)Charobj [2] ["Hair"];
		f3 = (int)Charobj [2] ["Face"];
		s3 = (int)Charobj [2] ["Shirt"];
		p3 = (int)Charobj [2] ["Pants"];
		sc3 = new Color32((byte)Charobj [2] ["SkinR"],(byte)Charobj [2] ["SkinG"],(byte)Charobj [2] ["SkinB"],1);

		h4 = (int)Charobj [3] ["Hair"];
		f4 = (int)Charobj [3] ["Face"];
		s4 = (int)Charobj [3] ["Shirt"];
		p4 = (int)Charobj [3] ["Pants"];
		sc4 = new Color32((byte)Charobj [3] ["SkinR"],(byte)Charobj [3] ["SkinG"],(byte)Charobj [3] ["SkinB"],1);

		h5 = (int)Charobj [4] ["Hair"];
		f5 = (int)Charobj [4] ["Face"];
		s5 = (int)Charobj [4] ["Shirt"];
		p5 = (int)Charobj [4] ["Pants"];
		sc5 = new Color32((byte)Charobj [4] ["SkinR"],(byte)Charobj [4] ["SkinG"],(byte)Charobj [4] ["SkinB"],1);

		h6 = (int)Charobj [5] ["Hair"];
		f6 = (int)Charobj [5] ["Face"];
		s6 = (int)Charobj [5] ["Shirt"];
		p6 = (int)Charobj [5] ["Pants"];
		sc6 = new Color32((byte)Charobj [5] ["SkinR"],(byte)Charobj [5] ["SkinG"],(byte)Charobj [5] ["SkinB"],1);

		Debug.Log ("working");

		playerhair = h1;
		playerface = f1;
		playershirt = s1;
		playerpants = p1;
		playerskinColor = sc1;
	}
}
