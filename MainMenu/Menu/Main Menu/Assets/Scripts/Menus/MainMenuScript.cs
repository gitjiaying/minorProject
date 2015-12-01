using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas optionsMenu;
	public Canvas highscoresMenu;
	public Button start;
	public Button character;
	public Button highscores;
	public Button options;
	public Button quit;
	public Button yes;
	public Button no;
	public GameObject main;
	public Toggle mute;


	void awake(){
		DontDestroyOnLoad (GameObject.Find ("PlayerAppearance"));
	}

	void Start () {
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

		quitMenu.enabled = false;
		optionsMenu.enabled = false;
		highscoresMenu.enabled = false;
	}
	void Update(){
		GameObject.Find ("mainMenu").GetComponent<AudioSource>().mute = GameManagerScript.soundEffects;

	}

	public void Play(){
		Application.LoadLevel ("Game");
	}

	public void Quit(){
		quitMenu.enabled = true;
		main.SetActive(false);
	}

	public void newCharacter(){
		Application.LoadLevel ("Characters");
	}

	public void Highscores(){
		highscoresMenu.enabled=true;
		main.SetActive (false);
	}

	public void Options(){
		optionsMenu.enabled = true;
		mute.isOn = !GameManagerScript.soundEffects;
		main.SetActive (false);
	}

	public void Menu(){
		quitMenu.enabled = false;
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

}
