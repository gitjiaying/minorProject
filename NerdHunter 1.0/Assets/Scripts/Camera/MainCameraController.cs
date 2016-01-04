using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public GameObject player;
    public Camera mainCamera;
    public float xSpeed;
    public float ySpeed;
    public Transform target;
    public int distance;
    public int ymin = -20;
    public int ymax = 80;

    private Vector3 offset;
    private float x = 0.0f;
    private float y = 0.0f;


    void Start () {

        //offset = transform.position - player.transform.position;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

    }
	
	void LateUpdate () {

       // transform.position = player.transform.position + offset;

        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, ymin, ymax);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;

        }


    }

   
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    void Update ()
    {
        
    }
}
