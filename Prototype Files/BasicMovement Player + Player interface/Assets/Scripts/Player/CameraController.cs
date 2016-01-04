using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

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
        if (Input.GetButtonDown("c"))
        {
            camera2.enabled = true;
            mainCamera.enabled = false;
        }
        else
        {
            mainCamera.enabled = true;
            camera2.enabled = false;
        }
    }
}
