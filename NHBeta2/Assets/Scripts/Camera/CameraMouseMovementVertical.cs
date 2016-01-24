using UnityEngine;
using System.Collections;

public class CameraMouseMovementVertical : MonoBehaviour
{
   
    public static float verticalspeed = 200f;
	public Transform target;
	public int offset;

    void Update()
    {
		Transform tempTrans = transform;
		Vector3 tempTarg = target.position;
		Vector3 tempRot = tempTrans.eulerAngles;

        float rotation = Input.GetAxis("Mouse Y") * verticalspeed;
		rotation *= Time.deltaTime;
		rotation = Mathf.Clamp (rotation, -5, 5);
		tempTarg.y = target.position.y + offset;

		if (tempRot.x < 80 ) { //if camera is in okay range, follow mouse movement
			tempTrans.RotateAround (tempTarg, target.right, rotation);
			tempRot = tempTrans.eulerAngles;
			tempRot.z = 0;
			tempTrans.eulerAngles = tempRot;
		}
		if (tempRot.x > 80 && tempRot.x < 180) {//if camera has gone too high, move it back into okay range
			float corSpeed = Mathf.Clamp (tempRot.x - 79.5f, 0, 30);
			tempTrans.RotateAround (tempTarg, target.right, 1f*corSpeed);
			tempRot = tempTrans.eulerAngles;
			tempRot.z = 0;
			tempTrans.eulerAngles = tempRot;
		}
		if (tempRot.x > 180) {//if camera is too low move back into okay range
			float corSpeed = Mathf.Clamp (360.5f-tempRot.x, 0, 30);
			tempTrans.RotateAround (tempTarg, target.right, -1f*corSpeed);
			tempRot = tempTrans.eulerAngles;
			tempRot.z = 0;
			tempTrans.eulerAngles = tempRot;
		}
		if (tempRot.x < 90 || tempRot.x > 350) {//safety to not let camare go out of range
			transform.position = tempTrans.position;
			transform.rotation = tempTrans.rotation;
		}
    }
}
