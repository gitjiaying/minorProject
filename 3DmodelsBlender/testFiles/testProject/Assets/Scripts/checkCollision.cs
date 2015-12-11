using UnityEngine;
using System.Collections;

public class checkCollision : MonoBehaviour {
	public bool fail =false;
	void OnTriggerStay(Collider col) {
		if (col.gameObject.CompareTag ("building") || col.gameObject.CompareTag ("ground")) {

			fail= true;
			Debug.Log("fail");
			Destroy(gameObject);
		}
	}
	
}
