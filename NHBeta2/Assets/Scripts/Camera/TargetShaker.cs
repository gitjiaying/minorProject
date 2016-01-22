using UnityEngine;
using System.Collections;

public class TargetShaker : MonoBehaviour {
	public Transform target;

	float shakeTime;
	float shakeAmount;
	float shakeDecreaser;

	Vector3 thisposition;

	bool alive;
	
	void OnEnable() {
		shakeTime = 1f;
		shakeDecreaser = 1f;
	}

	void Update() {
		thisposition = transform.localPosition;
		if (shakeTime > 0f) {
			shakeAmount = Random.Range (0.5f, 1f);
			ShakeTarget (true, shakeAmount);
			shakeAmount = Random.Range (0.5f, 1f);
			ShakeTarget (false, shakeAmount);
		} else {
			transform.localPosition = target.localPosition;
			this.enabled = false;
		}

		alive = GameManagerScript.alive;
		if (!alive) {
			this.enabled = false;
		}
	}

	void ShakeTarget(bool up, float shakeAmount) {
		if (up) {
			thisposition.y += shakeAmount;
		} else {
			thisposition.y -= shakeAmount;
		}
		transform.localPosition = thisposition;
		shakeTime -= Time.deltaTime * shakeDecreaser;
	}
}
