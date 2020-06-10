using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtMouse : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform camTransform;
    float xRotation = 0f;
    float yRotation = 180f;
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
        yRotation += mouseX;

        camTransform.SetPositionAndRotation(camTransform.position, Quaternion.Euler(Vector3.right * xRotation + Vector3.up * yRotation));
    }
}
