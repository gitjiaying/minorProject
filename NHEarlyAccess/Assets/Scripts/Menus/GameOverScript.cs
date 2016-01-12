using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public Button backToMain;
	public Canvas pause;

	void Start () {
		backToMain = backToMain.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void mainMenu(){
		Time.timeScale = 1;
		Application.LoadLevel (0);
		GameManagerScript.pause = false;
	}
	public void resume(){
		Time.timeScale = 1;
		pause.enabled = false;
		GameManagerScript.pause = false;
	}
}
