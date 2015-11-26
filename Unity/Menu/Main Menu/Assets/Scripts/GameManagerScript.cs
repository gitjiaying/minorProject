using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public static int playerhair;
	public static int playerface;
	public static int playershirt;
	public static int playerpants;
	public static Color32 playerskinColor;
	public static int playerstamina;
	public static int playerhealth;
	public int playerhair1;
	public int playerface1;
	public int playershirt1;
	public int playerpants1;
	public Color32 playerskinColor1;
	public int playerstamina1;
	public int playerhealth1;
	// Use this for initialization
	private static bool created = false;
	public bool bleh;

	
	void Awake() {
		if (!created) {
			// this is the first instance - make it persist
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		} 
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerhair);
		Debug.Log (playerface);

		playerhair = playerhair1;
	}

}
