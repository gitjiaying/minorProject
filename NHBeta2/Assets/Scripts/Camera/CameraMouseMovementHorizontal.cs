using UnityEngine;
using System.Collections;

public class CameraMouseMovementHorizontal : MonoBehaviour {

    public static float horizontalspeed = 400f;

    public static float rotation;
    public Transform target;
    public int ymin = -20;
    public int ymax = 80;
    private int orbitDistance;


    void Start ()
    {
        orbitDistance = 0;

    }
	
	
	void Update ()
    {
        
       // transform.RotateAround(target.position, Vector3.up, rotation);



       // transform.Rotate(0,rotation,0) ;
       // Vector3 curPos = transform.position;


        
    }
    void LateUpdate()
    {
		Orbit ();
    }

    void Orbit()
    {
        rotation = Input.GetAxis("Mouse X") * horizontalspeed;
        rotation *= Time.deltaTime;
        if (target != null)
        {
            // Keep us at orbitDistance from target
            transform.position = target.position;
            //transform.RotateAround(target.position, Vector3.up, rotation);
			transform.rotation=target.rotation;
			transform.Rotate (new Vector3 (0,180,0));
            Vector3 pos = transform.position;
            //pos.y= 5;
            transform.position = pos;
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
     {
        angle += 360;
     }

        if (angle > 360)
     {
        angle -= 360;
     }
     return Mathf.Clamp(angle, min, max);
    }
}
