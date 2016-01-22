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

    void Orbit()
	{
		rotation = Input.GetAxis ("Mouse X") * horizontalspeed;
		rotation *= Time.deltaTime;
		if (target != null) {
			// Keep us at orbitDistance from target
			float xpos = target.position.x;
			float zpos = target.position.z;
			Vector3 pos = transform.position;
			pos.x = xpos;
			pos.z = zpos;
			transform.position = pos;

			transform.rotation = target.rotation;
			transform.Rotate (new Vector3 (0, 180, 0));
		}
	}
}
