using UnityEngine;
using System.Collections;

public class GeoMovement : MonoBehaviour {

	public float MovementSpeed;
	public float tumble;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		
		rb.AddForce(transform.forward * MovementSpeed * -100.0f);
		rb.angularVelocity = Random.insideUnitSphere * tumble;
		if (this.name != "GEOTest") {
			Invoke ("destroy", 3);
		}
	}
	void destroy(){
		Destroy (gameObject);
		GameManagerScript.geoThrown++;
	}
}
