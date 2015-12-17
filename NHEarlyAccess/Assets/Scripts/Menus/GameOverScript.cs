using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public Button backToMain;
	// Use this for initialization
	void Start () {
		backToMain = backToMain.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void mainMenu(){
		Application.LoadLevel (0);
	}
}
