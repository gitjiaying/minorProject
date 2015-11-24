using UnityEngine;
using System.Collections;

public class CharAppearance : MonoBehaviour {

	public int index;
	public int hair;
	public int face;
	public int shirt;
	public int pants;
	public Color32 skinColor;
	public int stamina;
	public int health;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setAppearance(){
		PlayerAppearance.hair = hair;
		PlayerAppearance.face = face;
		PlayerAppearance.shirt = shirt;
		PlayerAppearance.pants = pants;
		PlayerAppearance.skinColor = skinColor;
	}
}
