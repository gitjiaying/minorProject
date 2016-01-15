using UnityEngine;
using System.Collections;

public class GeoShoot : MonoBehaviour {

	public float fireRate;
	public GameObject Geo;
	public Transform shotSpawn;
	private float nextFire;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("mouse 0") && Time.time > nextFire){
			if(GameManagerScript.geo){
			Instantiate(Geo, shotSpawn.position, shotSpawn.rotation);
			
			nextFire = Time.time + fireRate;
            GameManagerScript.geoThrown++;
            Debug.Log("thrown " + GameManagerScript.geoThrown);
            }
		}
	}
}
