using UnityEngine;
using System.Collections;

public class RotateChars : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CharMenuScript.charIndex != int.Parse (this.tag)) {
			transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
		} else {transform.LookAt(new Vector3(0,0,20));}
	}
}
