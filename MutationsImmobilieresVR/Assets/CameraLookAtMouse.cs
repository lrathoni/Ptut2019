using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtMouse : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform camTransform;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camTransform.Rotate(Vector3.right * xRotation);
        camTransform.Rotate(Vector3.up * mouseX);
    }
}
