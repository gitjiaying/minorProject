using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour
{
    Camera[] CameraArray;
    int CurrentCamera = 0;
    float KeyDelay = 0.4f;
    float LastKeyInput = 0.0f;

    void Start()
    { 
            // Disable all cameras except for the startup camera
        for (int i = 0; i < CameraArray.Length; i++){
            if (CurrentCamera == i)
                CameraArray[i].gameObject.active = true;
            else
                CameraArray[i].gameObject.active = false;
        }
    }

    void Update()
    {
        // Prevent switching multiple times from one key press
        if (Input.GetKey("f") && LastKeyInput + KeyDelay <= Time.realtimeSinceStartup) 
        {
            if (CurrentCamera + 1 < CameraArray.Length)
            {
                // Disable current camera and enable next camera
                CameraArray[CurrentCamera].gameObject.active = false;
                CurrentCamera++;
                CameraArray[CurrentCamera].gameObject.active = true;
            }
            else
            {
                // Disable current camera and enable first camera
                CameraArray[CurrentCamera].gameObject.active = false;
                CurrentCamera = 0;
                CameraArray[CurrentCamera].gameObject.active = true;
            }
            LastKeyInput = Time.realtimeSinceStartup;
        }
    }
}