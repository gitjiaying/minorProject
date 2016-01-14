using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;

public class LoginScript : MonoBehaviour {
	public GameObject wrong;
	public GameObject newuser;
	//public GameObject Play;
	public InputField username;
	public InputField password;
	public static int userID;
	private WWW www;

	private string UrlLog = "http://drproject.twi.tudelft.nl:8085/login";
	private string UrlReg = "http://drproject.twi.tudelft.nl:8085/register";
	private JsonData obj;

	private bool loginStatus;
	// Use this for initialization
	void Start () {
		wrong.SetActive (false);
		newuser.SetActive (false);
		//Play.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void startcheck(){
		wrong.SetActive (false);
		newuser.SetActive (false);
		StartCoroutine(sendLogin(username.text,password.text));
		Invoke ("checkFields", 0.5f);
	}
	public void checkFields(){
		Debug.Log("working");
		if (loginStatus==true) {
			startGame();
		}else{
			wrong.SetActive (true);
		}
	}

	public void startGame(){
		Debug.Log ("Starting as user: " + userID);
		Application.LoadLevel ("MainMenu");
	}
	public void newUser(){
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
}
