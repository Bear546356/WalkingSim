using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Locks the mouse cursor to the center of the screen and hides it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input axes
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate vertical rotation and clamp it so you can't flip upside down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 59.291f);

        // Apply vertical rotation to the camera itself
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the entire player body horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}