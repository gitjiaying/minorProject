using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewCharMenuScript : MonoBehaviour {

	public Button hairLeft;
	public Button hairRight;
	public Button faceLeft;
	public Button faceRight;
	public Button shirtLeft;
	public Button shirtRight;
	public Button pantsLeft;
	public Button pantsRight;
	public Button save;
	public Button cancel;
	public Slider skinColor;
	public int hair;
	public int face;
	public int shirt;
	public int pants;
	public Color32 Skin;



	void Start () {
		//Instantiate new Character

		hairLeft = hairLeft.GetComponent<Button> ();
		hairRight = hairRight.GetComponent<Button> ();
		faceLeft = faceLeft.GetComponent<Button> ();
		faceRight = faceRight.GetComponent<Button> ();
		shirtLeft = shirtLeft.GetComponent<Button> ();
		shirtRight = shirtRight.GetComponent<Button> ();
		pantsLeft = pantsLeft.GetComponent<Button> ();
		pantsRight = pantsRight.GetComponent<Button> ();
		save = save.GetComponent<Button> ();
		cancel = cancel.GetComponent<Button> ();
		skinColor = skinColor.GetComponent<Slider> ();
		Skin = new Color32(255, 229, 200,1);
		hair = 0;
		face = 0;
		shirt = 0;
		pants = 0;

	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("Cube").GetComponent<Renderer> ().material.color = Skin;
		GameObject.Find ("NewCharMenu").GetComponent<AudioSource>().mute = MainMenuScript.soundEffects;
		//Character.setProperties 
	}
	public void nextHair () {
		if (hair == 4) {
			hair = 0;
		} else {
			hair++;
		}
	
	}
	public void prevHair(){
		if (hair == 0) {
			hair = 4;
		} else {
			hair--;
		}
	}
	public void nextFace(){
		if (face == 4) {
			face = 0;
		} else {
			face++;
		}
	}
	public void prevFace(){
		if (face == 0) {
			face = 4;
		} else {
			face--;
		}
	}
	public void nextShirt(){
		if (shirt== 4) {
			shirt = 0;
		} else {
			shirt++;
		}
	}
	public void prevShirt(){
		if (shirt == 0) {
			shirt = 4;
		} else {
			shirt--;
		}
	}
	public void nextPants(){
		if (pants == 4) {
			pants = 0;
		} else {
			pants++;
		}
	}
	public void prevPants(){
		if (pants == 0) {
			pants = 4;
		} else {
			pants--;
		}
	}
	public void changeSkin(){
		if (skinColor.value == 0) {
			Skin = new Color32 (255, 229, 200,1);
		} else if (skinColor.value == 1) {
			Skin = new Color32(255, 206,180,1);
		}else if (skinColor.value == 2) {
			Skin = new Color32(240, 184,160,1);
		}else if (skinColor.value == 3) {
			Skin = new Color32(210, 161,140,1);
		}else if (skinColor.value == 4) {
			Skin = new Color32(180, 138,120,1);
		}else if (skinColor.value == 5) {
			Skin = new Color32(150, 114,100,1);
		}else if (skinColor.value == 6) {
			Skin = new Color32(120, 92,80,1);
		}else if (skinColor.value == 7) {
			Skin = new Color32(90, 69,60,1);
		}else if (skinColor.value == 8) {
			Skin = new Color32(60, 46,40,1);
		}else if (skinColor.value == 9) {
			Skin = new Color32(45, 34,30,1);
		}


	}
	public void cancelChar(){
		Application.LoadLevel ("Characters");
	}
	public void saveChar(){
		//save current properties to a character

	}
}
