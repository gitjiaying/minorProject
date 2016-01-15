using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Transform target;
	public float radius = 1.0f;

	float speed = 5;
	Vector3[] path;
	int targetIndex;

	Vector3  rightBound;
	Vector3  leftBound;

	bool facingUnit;
	bool  newRequestReady;

	void Start() {
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);

		newRequestReady = false;
	}

	void Update(){
		float distance = Vector3.Distance (transform.position, target.position);
		Vector3 unitDirection = transform.position - target.position;
		float angle = Mathf.Asin(radius/distance);

		rightBound = RotateV3aboutY(unitDirection, -angle);
		leftBound  = RotateV3aboutY(unitDirection,  angle);

	//	Debug.DrawLine(target.position, target.position+target.forward*10, Color.red);
	//	Debug.DrawLine(target.position, target.position+rightBound*10, Color.blue);
	//	Debug.DrawLine(target.position, target.position+leftBound*10, Color.blue);

		Vector3 normalLeft = RotateV3aboutY(unitDirection, -(Mathf.PI/2+angle*3));
		Vector3 normalRight= RotateV3aboutY(unitDirection,  (Mathf.PI/2+angle*3));

	//	Debug.DrawLine(transform.position, transform.position+normalLeft*10, Color.red);
	//	Debug.DrawLine(transform.position, transform.position+normalRight*10, Color.red);

		facingUnit = V3InDirectionRange(transform.forward, leftBound, rightBound);

		if(distance < 2){
			StopCoroutine("FollowPath");
			newRequestReady = true;
		}
		else if(distance >=5 && newRequestReady){
			PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
			//StopCoroutine("FollowPath");
			newRequestReady = false;

		}
	//	if(distance<10 && distance>=4){
	//		if(Mathf.Abs(Mathf.Atan(transform.forward.z/transform.forward.x)-Mathf.Atan(unitDirection.z/unitDirection.x))<Mathf.PI/2){
	//		float probabilty = Random.Range(0.0f, 1.0f);
			//if(probabilty<0.5)
	//			transform.position = Vector3.MoveTowards(transform.position, transform.position+normalLeft, speed*Time.deltaTime);
			//else
			//	transform.position = Vector3.MoveTowards(transform.position, transform.position+normalRight, speed*Time.deltaTime);

	//		}
	//	}
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {

			if (transform.position == currentWaypoint) {
				PathRequestManager.RequestPath(transform.position,target.position,OnPathFound);
				targetIndex=0;

				targetIndex ++;
				//Debug.Log(currentWaypoint);

				if (targetIndex >= path.Length) {
					targetIndex =0;
					path = new Vector3[0];
				//yield break;
				}
				currentWaypoint = path[targetIndex];
			}
				transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);

			yield return null;
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

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}
