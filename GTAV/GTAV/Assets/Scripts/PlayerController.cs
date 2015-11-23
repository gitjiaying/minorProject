using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Animator Anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Anim.SetFloat("Speed", Input.GetAxis("Vertical"));

		Anim.SetBool("Running", Input.GetKey(KeyCode.LeftShift));
	}
}
