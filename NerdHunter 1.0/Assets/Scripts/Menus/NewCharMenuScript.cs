﻿using UnityEngine;
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
	public Button start;
	public Button save;
	//public Button cancel;
	public Slider skinColor;
	public int hair;
	public int face;
	public int shirt;
	public int pants;
	public Color32 Skin;
	public Canvas editMenu;
	public GameObject main;
	private CharAppearance charAp;




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
		start = start.GetComponent<Button> ();
		//cancel = cancel.GetComponent<Button> ();
		skinColor = skinColor.GetComponent<Slider> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void startEdit(){
		string charname = "Character " + CharMenuScript.charIndex.ToString ();
		charAp = GameObject.Find(charname).GetComponent<CharAppearance> ();
		Skin = charAp.skinColor;
		hair = charAp.hair;
		face = charAp.face;
		shirt = charAp.shirt;
		pants = charAp.pants;
		Debug.Log (Skin.b);
		setSlider ();
	}

	public void nextHair () {
		if (hair == 2) {
			hair = 0;
		} else {
			hair++;
		}
		charAp.hair = hair;
	
	}
	public void prevHair(){
		if (hair == 0) {
			hair = 2;
		} else {
			hair--;
		}
		charAp.hair = hair;
	}
	public void nextFace(){
		if (face == 3) {
			face = 0;
		} else {
			face++;
		}
		charAp.face = face;
	}
	public void prevFace(){
		if (face == 0) {
			face = 3;
		} else {
			face--;
		}
		charAp.face = face;
	}
	public void nextShirt(){
		if (shirt== 3) {
			shirt = 0;
		} else {
			shirt++;
		}
		charAp.shirt = shirt;
	}
	public void prevShirt(){
		if (shirt == 0) {
			shirt = 3;
		} else {
			shirt--;
		}
		charAp.shirt = shirt;
	}
	public void nextPants(){
		if (pants == 4) {
			pants = 0;
		} else {
			pants++;
		}
		charAp.pants = pants;

	}
	public void prevPants(){
		if (pants == 0) {
			pants = 4;
		} else {
			pants--;
		}
		charAp.pants = pants;

	}
	public void changeSkin(){

		switch ((int)skinColor.value)
		{
		case 0:
			Skin = new Color32 (255, 229, 200,1);
			break;
		case 1:
			Skin = new Color32(255, 206,180,1);
			break;
		case 2:
			Skin = new Color32(240, 184,160,1);
			break;
		case 3:
			Skin = new Color32(210, 161,140,1);
			break;
		case 4:
			Skin = new Color32(180, 138,120,1);
			break;
		case 5:
			Skin = new Color32(150, 114,100,1);
			break;
		case 6:
			Skin = new Color32(120, 92,80,1);
			break;
		case 7:
			Skin = new Color32(90, 69,60,1);
			break;
		case 8:
			Skin = new Color32(60, 46,40,1);
			break;
		case 9:
			Skin = new Color32(45, 34,30,1);
			break;
		}
		charAp.skinColor = Skin;
	}

	private void setSlider(){
		if (Skin.b == 200) {
			skinColor.value = 0;
		}
		else if (Skin.b == 180) {
			skinColor.value = 1;
		}
		else if (Skin.b == 160) {
			skinColor.value = 2;
		}
		else if (Skin.b == 140) {
			skinColor.value = 3;
		}
		else if (Skin.b == 120) {
			skinColor.value = 4;
		}
		else if (Skin.b == 100) {
			skinColor.value = 5;
		}
		else if (Skin.b == 80) {
			skinColor.value = 6;
		}
		else if (Skin.b == 60) {
			skinColor.value = 7;
		}
		else if (Skin.b == 40) {
			skinColor.value = 8;
		}
		else if (Skin.b == 30) {
			skinColor.value = 9;
		} 
		else {
			Debug.Log ("error color");
			skinColor.value=9;
		}
			
	}

	
	public void saveChar(){
		charAp.hair = hair;
		charAp.face = face;
		charAp.shirt = shirt;
		charAp.pants = pants;
		charAp.skinColor = Skin;

		Skin = new Color32 (255, 229, 200,1);
		hair = 0;
		face = 0;
		shirt = 0;
		pants = 0;

		editMenu.enabled = false;
		main.SetActive (true);
	}
}
