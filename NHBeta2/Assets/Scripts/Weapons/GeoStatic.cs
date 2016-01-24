using UnityEngine;
using System.Collections;

public class GeoStatic : MonoBehaviour {

	private float nextFire;

	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () { //animates when geo is thrown
		if(Input.GetKeyDown("mouse 0") && /*Time.time > nextFire*/ !anim.IsPlaying("Cube|GeoGooi")){

			anim.Play("Cube|GeoGooi");
		}
	}
}
