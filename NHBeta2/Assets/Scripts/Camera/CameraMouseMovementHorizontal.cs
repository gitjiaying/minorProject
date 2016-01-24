using UnityEngine;
using System.Collections;

public class CameraMouseMovementHorizontal : MonoBehaviour {

    public static float horizontalspeed = 200f;

    public static float rotation;
    public Transform target;
    public int ymin = -20;
    public int ymax = 80;

	public bool damaged;

	TargetShaker shaker;

    void Start ()
    {
		shaker = GetComponent<TargetShaker> ();
		shaker.enabled = false;
    }
	
	void Update ()
    {
		damaged = PlayerHealth.damaged;

		if (damaged) {
			shaker.enabled = true;
		}
    }

    void LateUpdate()
    {
		Orbit ();
    }

    void Orbit()//rotate camera horizontaly based on mouse movement
    {
		rotation = Input.GetAxis ("Mouse X") * horizontalspeed;
		rotation *= Time.deltaTime;
		if (target != null){
			Vector3 pos = transform.position;
			pos.x = target.position.x;//Set x and z coordinates to follow the player
            pos.z = target.position.z;
            transform.position = pos;

			transform.rotation = target.rotation;
			transform.Rotate (new Vector3 (0, 180, 0));
		}
	}
}
