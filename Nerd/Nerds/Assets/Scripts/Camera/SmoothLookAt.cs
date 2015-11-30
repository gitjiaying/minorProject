using UnityEngine;
using System.Collections;

public class SmoothLookAt : MonoBehaviour {

    public Transform target;
    public bool smooth = true;

    int damping = 6;
   

	void Start ()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

	}
	
	
	void LateUpdate ()
    {
        if (target)
        {
            if (smooth)
            {
                Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }
          else
            {
                transform.LookAt(target);
            }

        }
	
	}
}
