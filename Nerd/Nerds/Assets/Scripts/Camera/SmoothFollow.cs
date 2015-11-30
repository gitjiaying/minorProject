using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public Transform target;

    int distance = 10;
    float height = 10;
    int heightdamping = 2;
    int rotationdamping = 3;
	
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
