using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class LoginScript : MonoBehaviour {
	public GameObject wrong;
	public GameObject newuser;
	public InputField username;
	public InputField password;
	public static int userID;
	private WWW www;

	private string UrlLog = "http://drproject.twi.tudelft.nl:8085/login";
	private string UrlReg = "http://drproject.twi.tudelft.nl:8085/register";
	private JsonData obj;

	private string ScoreUrl = "http://drproject.twi.tudelft.nl:8085/getScore";
	private string CharUrl = "http://drproject.twi.tudelft.nl:8085/getCharacters";
	private JsonData Scoreobj;
	private JsonData Charobj;

	private bool loginStatus;

	void Start () {
		wrong.SetActive (false);
		newuser.SetActive (false);
	}
	
	public void startcheck(){
        //Start to check inputs with server
        wrong.SetActive (false);
		newuser.SetActive (false);
		StartCoroutine(sendLogin(username.text,password.text));
		Invoke ("checkFields", 0.5f);
	}
	public void checkFields(){
        //Start game or give error based on server response
        Debug.Log("working");
		if (loginStatus==true) {
			startGame();
		}else{
			wrong.SetActive (true);
		}
	}

	public void startGame(){//First loads characters and highscores, then starts the game
		Debug.Log ("Starting as user: " + userID);
		StartCoroutine (getScore ());
		Invoke ("sethighscores", 0.5f);

		StartCoroutine (getChar ());
		Invoke ("setChar", 0.5f);
		Invoke ("loadGame", 0.5f);
	}
	void loadGame(){
		Application.LoadLevel ("MainMenu");
	}

	public void newUser(){
        //Send new data to server to create a new character. Gives error if there are empty fields. If character is created, game starts
        wrong.SetActive (false);
		newuser.SetActive (false);
		if (username.text == "" || password.text == "") {
			newuser.SetActive (true);
		} else {
			StartCoroutine (SendReg(username.text,password.text));
			Invoke ("startcheck", 1);
		}
	}
	public void startOff(){
		Application.LoadLevel ("MainMenu");
	}

	IEnumerator sendLogin(string name , string password)
	{
		WWWForm dataParameters = new WWWForm();
		dataParameters.AddField("Password", password);
		dataParameters.AddField("Name", name);
		www = new WWW(UrlLog,dataParameters);
		yield return www;
		Debug.Log(www.text);
		obj = JsonMapper.ToObject(www.text);
		loginStatus = (bool)obj["Login"];

		if(loginStatus == true){
			userID = (int)obj["UserId"]; // Moet je mee sturen om dingen opteslaan per speler
		}
	}

	IEnumerator SendReg(string name , string password)
	{
		WWWForm dataParameters = new WWWForm();
		dataParameters.AddField("Password", password);
		dataParameters.AddField("Name", name);
		WWW www = new WWW(UrlReg,dataParameters);
		yield return www;
		Debug.Log(www.text);
		obj = JsonMapper.ToObject(www.text);
		loginStatus = (bool)obj["regStatus"];
		Debug.Log(loginStatus);
	}

	IEnumerator getScore()
	{
		WWWForm dataParameters = new WWWForm();
		Debug.Log ("dit werkt");
		dataParameters.AddField("UserId", LoginScript.userID);
		WWW www = new WWW(ScoreUrl,dataParameters);
		yield return www;
		Debug.Log(www.text);

		Scoreobj = JsonMapper.ToObject(www.text);
	}
	private void sethighscores(){
		for(int i = 0; i < 5; i++){
			GameManagerScript.scores.Add((int)Scoreobj [i] ["HighScore"]);
		}
		Debug.Log(GameManagerScript.scores.Count);
	}

	IEnumerator getChar()
	{
		WWWForm dataParameters = new WWWForm();
		dataParameters.AddField("UserId", LoginScript.userID);
		WWW www = new WWW(CharUrl,dataParameters);
		yield return www;
		Debug.Log(www.text);

		Charobj = JsonMapper.ToObject(www.text);
	}
	private void setChar(){
		//Characters Appearance
		GameManagerScript.h1 = (int)Charobj [0] ["Hair"];
		GameManagerScript.f1 = (int)Charobj [0] ["Face"];
		GameManagerScript.s1 = (int)Charobj [0] ["Shirt"];
		GameManagerScript.p1 = (int)Charobj [0] ["Pants"];
		GameManagerScript.sc1 = new Color32((byte)Charobj [0] ["SkinR"],(byte)Charobj [0] ["SkinG"],(byte)Charobj [0] ["SkinB"],1);

		GameManagerScript.h2 = (int)Charobj [1] ["Hair"];
		GameManagerScript.f2 = (int)Charobj [1] ["Face"];
		GameManagerScript.s2 = (int)Charobj [1] ["Shirt"];
		GameManagerScript.p2 = (int)Charobj [1] ["Pants"];
		GameManagerScript.sc2 = new Color32((byte)Charobj [1] ["SkinR"],(byte)Charobj [1] ["SkinG"],(byte)Charobj [1] ["SkinB"],1);

		GameManagerScript.h3 = (int)Charobj [2] ["Hair"];
		GameManagerScript.f3 = (int)Charobj [2] ["Face"];
		GameManagerScript.s3 = (int)Charobj [2] ["Shirt"];
		GameManagerScript.p3 = (int)Charobj [2] ["Pants"];
		GameManagerScript.sc3 = new Color32((byte)Charobj [2] ["SkinR"],(byte)Charobj [2] ["SkinG"],(byte)Charobj [2] ["SkinB"],1);

		GameManagerScript.h4 = (int)Charobj [3] ["Hair"];
		GameManagerScript.f4 = (int)Charobj [3] ["Face"];
		GameManagerScript.s4 = (int)Charobj [3] ["Shirt"];
		GameManagerScript.p4 = (int)Charobj [3] ["Pants"];
		GameManagerScript.sc4 = new Color32((byte)Charobj [3] ["SkinR"],(byte)Charobj [3] ["SkinG"],(byte)Charobj [3] ["SkinB"],1);

		GameManagerScript.h5 = (int)Charobj [4] ["Hair"];
		GameManagerScript.f5 = (int)Charobj [4] ["Face"];
		GameManagerScript.s5 = (int)Charobj [4] ["Shirt"];
		GameManagerScript.p5 = (int)Charobj [4] ["Pants"];
		GameManagerScript.sc5 = new Color32((byte)Charobj [4] ["SkinR"],(byte)Charobj [4] ["SkinG"],(byte)Charobj [4] ["SkinB"],1);

		GameManagerScript.h6 = (int)Charobj [5] ["Hair"];
		GameManagerScript.f6 = (int)Charobj [5] ["Face"];
		GameManagerScript.s6 = (int)Charobj [5] ["Shirt"];
		GameManagerScript.p6 = (int)Charobj [5] ["Pants"];
		GameManagerScript.sc6 = new Color32((byte)Charobj [5] ["SkinR"],(byte)Charobj [5] ["SkinG"],(byte)Charobj [5] ["SkinB"],1);

		Debug.Log ("working");

		GameManagerScript.playerhair = GameManagerScript.h1;
		GameManagerScript.playerface = GameManagerScript.f1;
		GameManagerScript.playershirt = GameManagerScript.s1;
		GameManagerScript.playerpants = GameManagerScript.p1;
		GameManagerScript.playerskinColor = GameManagerScript.sc1;
	}
}
