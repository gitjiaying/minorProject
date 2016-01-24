using UnityEngine;
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
	public float rotSpeed;
	public CharAppearance char1;
	public CharAppearance char2;
	public CharAppearance char3;
	public CharAppearance char4;
	public CharAppearance char5;
	public CharAppearance char6;
	public static int charIndex=1;
	private float from;
	private float to;
	private float yDegree;
	private float lerpValue;
	public AudioListener listen;


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
		char1.getAppearance ();
		char2.getAppearance ();
		char3.getAppearance ();
		char4.getAppearance ();
		char5.getAppearance ();
		char6.getAppearance ();
	
		lerpValue = 0f;

		to = schijf.transform.eulerAngles.y;
		from = schijf.transform.eulerAngles.y;
	}
	void Update(){
        //Rotate schijf smoothly to rotation "to"
        lerpValue += rotSpeed * Time.deltaTime;
		listen.enabled = GameManagerScript.music;
		yDegree = Mathf.LerpAngle(from, to, lerpValue);
		schijf.transform.eulerAngles = new Vector3 (0, yDegree, 0);
	}
	
	public void next(){
        //Change "to" for rotation and ad one to charIndex
        to = schijf.transform.eulerAngles.y;
		from = schijf.transform.eulerAngles.y;
		to+= 60f;
		lerpValue = 0f;

		if (charIndex == 6) {
			charIndex = 1;
		} else {
			charIndex++;
		}
	}

	public void previous(){
        //Change "to" for rotation and subract one from charIndex
        from = schijf.transform.eulerAngles.y;
		to -= 60f;
		lerpValue = 0f;
		if (charIndex == 1) {
			charIndex = 6;
		} else {
			charIndex--;
		}
	}

	public void newChar(){
        //Change interface to edit
        editMenu.enabled = true;
		main.SetActive (false);
	}

	public void choose(){
        //Sets player appearance to currently selected character
        switch (charIndex)
		{
		case 6:
			char6.setAppearance();
			break;
		case 5:
			char5.setAppearance();
			break;
		case 4:
			char4.setAppearance();
			break;
		case 3:
			char3.setAppearance();
			break;
		case 2:
			char2.setAppearance();
			break;
		case 1:
			char1.setAppearance();
			break;
		}
		Application.LoadLevel ("MainMenu");
	}
	
	
}
