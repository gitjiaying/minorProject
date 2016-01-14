using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	bool facingUnit;

	public Transform seeker;
	public float radius = 0.5f;

	Vector3  rightBound;
	Vector3  leftBound;

	int speed = 5;

	void Update () {
		float distance = Vector3.Distance(transform.position , seeker.position);
		Vector3 unitDirection = seeker.position - transform.position;
		float angle = Mathf.Asin(radius/distance);


		rightBound = RotateV3aboutY(unitDirection, -angle);
		leftBound  = RotateV3aboutY(unitDirection,  angle);



		Vector3 normalLeft = RotateV3aboutY(unitDirection, -(Mathf.PI/2+angle*3));
		Vector3 normalRight= RotateV3aboutY(unitDirection,  (Mathf.PI/2+angle*3));

		Debug.DrawLine(transform.position, transform.position+transform.forward*10, Color.red);
		Debug.DrawLine(transform.position, transform.position+rightBound*10, Color.blue);
		Debug.DrawLine(transform.position, transform.position+leftBound*10, Color.blue);

		Debug.DrawLine(seeker.position, seeker.position+normalLeft*10, Color.red);
		Debug.DrawLine(seeker.position, seeker.position+normalRight*10, Color.red);

		facingUnit = V3InDirectionRange(transform.forward, leftBound, rightBound);
		

		//Debug.Log(Mathf.Abs(Mathf.Atan(transform.forward.z/transform.forward.x)-Mathf.Atan(unitDirection.z/unitDirection.x)));

		if(distance<10 && distance>3){
			if(Mathf.Abs(Mathf.Atan(transform.forward.z/transform.forward.x)-Mathf.Atan(unitDirection.z/unitDirection.x))<Mathf.PI/2){
			float probabilty = Random.Range(0.0f, 1.0f);
			if(probabilty<0.5)
				seeker.position = Vector3.MoveTowards(seeker.position, seeker.position+normalLeft, speed*Time.deltaTime);
			else
				seeker.position = Vector3.MoveTowards(seeker.position, seeker.position+normalRight, speed*Time.deltaTime);
			}
		}

	}

	public bool V3InDirectionRange(Vector3 forward, Vector3 left, Vector3 right){
		float angleLeftBound = Mathf.Atan(left.z/left.x);
		float angleRightBound = Mathf.Atan(right.z/right.x);
		float angleForward = Mathf.Atan(forward.z/forward.x);

		return (angleForward<=angleLeftBound && angleForward>=angleRightBound)?true:false;
	}

	public Vector3 RotateV3aboutY(Vector3 vector, float angle){
		Vector3 newVector;
		newVector.x = Mathf.Cos(angle)*vector.x - Mathf.Sin(angle)*vector.z;
		newVector.y = vector.y;
		newVector.z = Mathf.Sin(angle)*vector.x + Mathf.Cos(angle)*vector.z;

		return newVector;
	}







	
}
