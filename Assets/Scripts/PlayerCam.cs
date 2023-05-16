using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orienteation;
    float xRotation;
    float yRotation;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;

        float minXRotation = -90f;
        float maxXRotation = 90f;
        xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation); // Prevents player from looking too far up or down

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orienteation.rotation = Quaternion.Euler(0f, yRotation, 0f);

    }
}
