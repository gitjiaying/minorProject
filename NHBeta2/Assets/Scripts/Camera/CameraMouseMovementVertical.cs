using UnityEngine;
using System.Collections;

public class CameraMouseMovementVertical : MonoBehaviour
{
   
    private float verticalspeed = 400f;
	public Transform target;
	public int offset;

    void Start()
    {
       

    }


    void Update()
    {
        float rotation = Input.GetAxis("Mouse Y") * verticalspeed;
		rotation *= Time.deltaTime;
		Vector3 temp = target.position;
		temp.y = target.position.y + offset;
		transform.RotateAround (temp, target.right, rotation);
		temp = this.transform.eulerAngles;
		temp.z = 0;
		this.transform.eulerAngles = temp;
    }

}
