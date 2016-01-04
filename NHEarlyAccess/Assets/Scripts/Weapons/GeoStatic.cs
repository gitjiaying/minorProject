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
	void Update () {
		if(Input.GetKeyDown("mouse 0") && /*Time.time > nextFire*/ !anim.IsPlaying("Cube|GeoGooi")){

			anim.Play("Cube|GeoGooi");
			
			//nextFire = Time.time + fireRate;
			
		}
	}
}
