using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public GameObject player;
    public Camera mainCamera;
    public Camera camera2;

    private Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = player.transform.position + offset;
	
	}

    void Update ()
    {
        
    }
}
