using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public Button backToMain;
    public Button options;
	public Canvas pause;
    public Canvas optionsMenu;
    public Toggle mute;
    public Toggle music;
    public Toggle ThirdPerson;



    void Start () {
		backToMain = backToMain.GetComponent<Button> ();
        options = options.GetComponent<Button>();


        optionsMenu.enabled = false;
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
    public void Options()
    {
        optionsMenu.enabled = true;
        pause.enabled = false;
        mute.isOn = !GameManagerScript.soundEffects;
        music.isOn = GameManagerScript.music;
        ThirdPerson.isOn = GameManagerScript.thirdPerson;
    }
    public void Back()
    {
        optionsMenu.enabled = false;
        pause.enabled = true;
    }
    public void muteFX()
    {
        GameManagerScript.soundEffects = !mute.isOn;
    }
    public void muteMusic()
    {
        GameManagerScript.music = music.isOn;
    }
    public void FirstPerson()
    {
        GameManagerScript.thirdPerson = ThirdPerson.isOn;
    }
}
