using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject Book;
	//public float fireRate;


	public Transform shotSpawn;
	private float nextFire;

	private Animation anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("mouse 0") && /*Time.time > nextFire*/ !anim.IsPlaying("Default Take")){

			anim.Play("Default Take");
			Instantiate(Book, shotSpawn.position, shotSpawn.rotation);

			//nextFire = Time.time + fireRate;
			/*Kan ook met aanpasbare fireRate
			 */
		}
	}
	
}
