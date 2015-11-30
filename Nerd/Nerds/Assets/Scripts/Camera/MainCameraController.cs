using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public GameObject player;
    public Camera mainCamera;
    public float xSpeed;
    public float ySpeed;
    public Transform target;
    public int distance;

    private Vector3 offset;
    private float x;
    private float y;

    // Use this for initialization
    void Start () {

        offset = transform.position - player.transform.position;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

    }
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = player.transform.position + offset;
        Turning();
        

    }

    void Turning()
    {
        int ymin = -20;
        int ymax = 80;
        

        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, ymin, ymax);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance);

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
