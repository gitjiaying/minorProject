using UnityEngine;
using System.Collections;


public class BobScript : MonoBehaviour {
	public int amplitude;
	private float y0;
	private Vector3 pos;
	public int speed;
	// Use this for initialization
	void Start () {
		y0 = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		pos.y = y0 + amplitude * Mathf.Sin (speed * Time.deltaTime);
		this.transform.position=pos;
	}
}
