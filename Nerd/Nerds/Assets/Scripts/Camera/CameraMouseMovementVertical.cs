using UnityEngine;
using System.Collections;

public class CameraMouseMovementVertical : MonoBehaviour
{
   
    private float verticalspeed = 5;
    private Vector3 offset;

    void Start()
    {
       

    }


    void Update()
    {
        float rotation = Input.GetAxis("Mouse Y") * verticalspeed;
        rotation *= Time.deltaTime * verticalspeed;

        transform.Rotate(-rotation, 0, 0);
    }

}
