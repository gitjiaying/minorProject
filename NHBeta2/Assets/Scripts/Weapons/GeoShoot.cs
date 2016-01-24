using UnityEngine;
using System.Collections;

public class GeoShoot : MonoBehaviour {

	public float fireRate;
	public GameObject Geo;
	public Transform shotSpawn;
	private float nextFire;

	AudioSource source;
	
	
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {//shoots a geo on mouseclick with a set max fire rate
		if(Input.GetKeyDown("mouse 0") && Time.time > nextFire){
			if(GameManagerScript.geo){
			Instantiate(Geo, shotSpawn.position, shotSpawn.rotation);
			source.PlayOneShot((AudioClip)Resources.Load("Music/Effects/Throw"));

			nextFire = Time.time + fireRate;
            GameManagerScript.geoThrown++;
            Debug.Log("thrown " + GameManagerScript.geoThrown);
            }
		}
	}
}
