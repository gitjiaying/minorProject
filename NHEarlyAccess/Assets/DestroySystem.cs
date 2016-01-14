using UnityEngine;
using System.Collections;

public class DestroySystem : MonoBehaviour {

	
	void Start ()
    {
        Invoke("destroy", 2);
	
	}
	
	
	void destroy ()
    {
        Destroy(this.gameObject);
	
	}
}
