﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharMenuScript : MonoBehaviour {
	
	public Button left;
	public Button right;
	public Button create;
	public Button select;
	public Canvas editMenu;
	public GameObject schijf;
	public GameObject main;
	public CharAppearance char1;
	public CharAppearance char2;
	public CharAppearance char3;
	public CharAppearance char4;
	public CharAppearance char5;
	public CharAppearance char6;
	public static int charIndex=1;


	void Start () {
		left = left.GetComponent<Button> ();
		right = right.GetComponent<Button> ();
		create = create.GetComponent<Button> ();
		select = select.GetComponent<Button> ();
		editMenu = editMenu.GetComponent<Canvas> ();
		char1 = char1.GetComponent<CharAppearance> ();
		char2 = char2.GetComponent<CharAppearance> ();
		char3 = char3.GetComponent<CharAppearance> ();
		char4 = char4.GetComponent<CharAppearance> ();
		char5 = char5.GetComponent<CharAppearance> ();
		char6 = char6.GetComponent<CharAppearance> ();
		charIndex=1;
		editMenu.enabled = false;
	}
	void Update(){
		GameObject.Find ("CharMenu").GetComponent<AudioSource>().mute = MainMenuScript.soundEffects;

	}
	
	public void next(){
		schijf.transform.Rotate(new Vector3(0,60,0));

		if (charIndex == 6) {
			charIndex = 1;
		} else {
			charIndex++;
		}
		Debug.Log (charIndex);
	}

	public void previous(){
		schijf.transform.Rotate(new Vector3(0,-60,0));
		if (charIndex == 1) {
			charIndex = 6;
		} else {
			charIndex--;
		}
		Debug.Log (charIndex);
	}

	public void newChar(){
		editMenu.enabled = true;
		main.SetActive (false);
	}

	public void choose(){
		switch (charIndex)
		{
		case 5:
			char6.setAppearance();
			break;
		case 4:
			char5.setAppearance();
			break;
		case 3:
			char4.setAppearance();
			break;
		case 2:
			char3.setAppearance();
			break;
		case 1:
			char2.setAppearance();
			break;
		case 0:
			char1.setAppearance();
			break;
		}
		Application.LoadLevel ("MainMenu");
	}
	
	
}
