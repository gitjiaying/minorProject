using UnityEngine;
using System.Collections;

public class CameraTurn : MonoBehaviour {

    public Transform target;
    public float rotSpeed;
	
	void Update ()
    {
        Vector3 targetpos = target.position;
        targetpos.y = transform.position.y;
        Quaternion targetdir = Quaternion.LookRotation(-(targetpos - transform.position));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetdir, rotSpeed * Time.deltaTime);
    }
}
