using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Animator Anim;
	public Rigidbody rb;

	 bool canJump;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
		Anim.SetFloat("Speed", Input.GetAxis("Vertical"));

		Anim.SetBool("Running", Input.GetKey(KeyCode.LeftShift));

		if(Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			Anim.SetTrigger("Jumping");
			rb.velocity = rb.velocity + new Vector3(0, 4, 0);
		}



	}

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
     {
     	 Debug.Log("groundHit");
         canJump = true;
     }
    }

    void OnCollisionExit(Collision col)
    {
    if(col.gameObject.tag == "ground")
     {
     	 Debug.Log("groundFalse");
         canJump = false;
     }
   }
}
