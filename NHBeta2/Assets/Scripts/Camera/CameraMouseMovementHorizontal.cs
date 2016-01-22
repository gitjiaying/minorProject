using UnityEngine;
using System.Collections;

public class CameraMouseMovementHorizontal : MonoBehaviour {

    public static float horizontalspeed = 200f;

    public static float rotation;
    public Transform target;
    public int ymin = -20;
    public int ymax = 80;


    void Start ()
    {


    }
	
	
	void Update ()
    {
  
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
			transform.position = target.position;
			transform.rotation = target.rotation;
			transform.Rotate (new Vector3 (0, 180, 0));
			Vector3 pos = transform.position;
			transform.position = pos;
		}
	}
}
