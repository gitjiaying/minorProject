using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public Button backToMain;
    public Button options;
	public Canvas pause;
    public Canvas optionsMenu;
    public Toggle music;
    public Toggle ThirdPerson;
    public CameraSwitch Switch;
	public Slider slider;


    void Start () {
		Time.timeScale = 1;
		backToMain = backToMain.GetComponent<Button> ();
        options = options.GetComponent<Button>();
		slider = slider.GetComponent<Slider> ();
		slider.value=CameraMouseMovementHorizontal.horizontalspeed;
        optionsMenu.enabled = false;
    }

    void Update()
    {
        //Set switch based on thirdperson setting
        Switch.enabled = GameManagerScript.thirdperson;
    }

    public void mainMenu()//unpause time and load menu
    { 
        Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
		GameManagerScript.pause = false;
	}
	public void resume()//unpause time and get rid of pause menu
    {
        Time.timeScale = 1;
		pause.enabled = false;
		GameManagerScript.pause = false;
		Cursor.visible = false;
	}
    public void Options()//hide pause menu, show options menu
    {
        optionsMenu.enabled = true;
        pause.enabled = false;
        music.isOn = GameManagerScript.music;
        ThirdPerson.isOn = GameManagerScript.thirdPerson;
    }
    public void Back()
    {
        optionsMenu.enabled = false;
        pause.enabled = true;
    }
    public void muteMusic()
    {
        GameManagerScript.music = music.isOn;
    }
    public void FirstPerson()
    {
        GameManagerScript.thirdPerson = ThirdPerson.isOn;
    }
	public void sensitivity(){
		CameraMouseMovementHorizontal.horizontalspeed = slider.value;
	}
	public void retry(){
		Application.LoadLevel ("Game");

	}
}
