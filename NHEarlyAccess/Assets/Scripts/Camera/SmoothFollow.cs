using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public int distance = 10;
    public float height = 10;
    public int heightdamping = 2;
    public int rotationdamping = 3;
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (!target)
        {
            return;
        }

        float WantedRotationAngle = target.eulerAngles.y;
        float WantedHeight = target.position.y + height;

        float CurrentRotationAngle = transform.eulerAngles.y;
        float CurrentHeight = transform.position.y;

        CurrentRotationAngle = Mathf.LerpAngle(CurrentRotationAngle, WantedRotationAngle, rotationdamping * Time.deltaTime);
        CurrentHeight = Mathf.Lerp(CurrentHeight, WantedHeight, heightdamping * Time.deltaTime);

        Quaternion CurrentRotation = Quaternion.Euler(0f, CurrentRotationAngle, 0f);

        transform.position = target.position;
        transform.position -= CurrentRotation * Vector3.forward * distance;
        float currenty = transform.position.y;
        currenty = CurrentHeight;
        transform.LookAt(target);
	
	}
}
