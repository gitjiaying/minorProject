using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharMenuScript : MonoBehaviour {
	
	public Button left;
	public Button right;
	public Button create;
	public Button select;
	public GameObject schijf;

	void Start () {
		left = left.GetComponent<Button> ();
		right = right.GetComponent<Button> ();
		create = create.GetComponent<Button> ();
		select = select.GetComponent<Button> ();
	}
	void Update(){
		GameObject.Find ("CharMenu").GetComponent<AudioSource>().mute = MainMenuScript.soundEffects;
	}
	
	public void next(){
		schijf.transform.Rotate(new Vector3(0,30,0));
	}

	public void previous(){
		schijf.transform.Rotate(new Vector3(0,-30,0));
	}

	public void newChar(){
		Application.LoadLevel("NewCharacter");
	}

	public void choose(){
		Application.LoadLevel ("MainMenu");
	}


}
