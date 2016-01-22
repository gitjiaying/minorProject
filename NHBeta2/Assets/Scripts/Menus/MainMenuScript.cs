using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas optionsMenu;
	public Canvas highscoresMenu;
	public GameObject controls;
	public Button start;
	public Button character;
	public Button highscores;
	public Button options;
	public Button quit;
	public Button yes;
	public Button no;
	public GameObject main;
	public Toggle mute;
	public Toggle music;
	public Toggle ThirdPerson;
	public GameObject player;
	public Slider slider;
	static CameraMouseMovementHorizontal mouseHor;
	public Text h1;
	public Text h2;
	public Text h3;
	public Text h4;
	public Text h5;



	void awake(){
		DontDestroyOnLoad (GameObject.Find ("PlayerAppearance"));
	}

	void Start () {
		Time.timeScale = 1;
		quitMenu = quitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		highscoresMenu = highscoresMenu.GetComponent<Canvas> ();
		start = start.GetComponent<Button> ();
		character = character.GetComponent<Button> ();
		highscores = highscores.GetComponent<Button> ();
		options = options.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		yes = yes.GetComponent<Button> ();
		no = no.GetComponent<Button> ();
		mute = mute.GetComponent<Toggle> ();
		music = music.GetComponent<Toggle> ();
		ThirdPerson = ThirdPerson.GetComponent<Toggle> ();
		slider = slider.GetComponent<Slider> ();
		controls.SetActive (false);
		slider.value=CameraMouseMovementHorizontal.horizontalspeed;

		quitMenu.enabled = false;
		optionsMenu.enabled = false;
		highscoresMenu.enabled = false;
	}
	void Update(){
		GameObject.Find ("mainMenu").GetComponent<AudioSource>().mute = GameManagerScript.soundEffects;

	}

	public void Play(){
		controls.SetActive (true);
		Application.LoadLevel ("Game");
		Time.timeScale=1;
	}

	public void Quit(){
		quitMenu.enabled = true;
		player.SetActive (false);
		main.SetActive(false);

	}

	public void newCharacter(){
		Application.LoadLevel ("Characters");
	}

	public void Highscores(){
		highscoresMenu.enabled=true;
		player.SetActive (false);
		main.SetActive (false);

		getHighscores ();
	}

	public void Options(){
		optionsMenu.enabled = true;
		mute.isOn = !GameManagerScript.soundEffects;
		music.isOn = GameManagerScript.music;
		ThirdPerson.isOn = GameManagerScript.thirdPerson;
		main.SetActive (false);
	}

	public void Menu(){
		quitMenu.enabled = false;
		player.SetActive (true);
		highscoresMenu.enabled = false;
		optionsMenu.enabled = false;
		main.SetActive (true);
	}

	public void Exit(){
		Application.Quit ();
	}
	public void muteFX(){
		GameManagerScript.soundEffects=!mute.isOn;
	}
	public void muteMusic(){
		GameManagerScript.music = music.isOn;
	}
	public void FirstPerson(){
		GameManagerScript.thirdPerson = ThirdPerson.isOn;
	}

	void getHighscores(){
		List<int> highscores = new List<int> (0);
		List<int> scores = GameManagerScript.scores;
		foreach (int score in scores) {
			Debug.Log (score.ToString());
		}
		scores.Sort ();
		scores.Reverse ();
		Debug.Log ("sorted");
		foreach(int score in scores) {
			Debug.Log ("sorted"+ score.ToString());
		}
		foreach(int score in scores) {
			if(score !=null){
				highscores.Add(score);
			}
		}
		Debug.Log ("highscores made");
		foreach(int score in highscores){
			Debug.Log (score.ToString());
		}
		if (highscores.Count>4) {
			h5.text="5-"+highscores[4].ToString();
		}
		if (highscores.Count>3) {
			h4.text="4-"+highscores[3].ToString();
		}
		if (highscores.Count>2) {
			h3.text="3-"+highscores[2].ToString();
		}
		if (highscores.Count>1) {
			h2.text="2-"+highscores[1].ToString();
		}
		if (highscores.Count>0) {
			h1.text="1-"+highscores[0].ToString();
		}
	}
	public void sensitivity(){
		CameraMouseMovementHorizontal.horizontalspeed = slider.value;
		CameraMouseMovementVertical.verticalspeed = slider.value;
	}
}
