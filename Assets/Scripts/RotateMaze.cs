using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMaze : MonoBehaviour
{
    [SerializeField]
    float clampAngle = 20f;

    float xRotation;
    float zRotation;

    //[SerializeField]
    //Transform roof;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);

        zRotation += mouseX;
        zRotation = Mathf.Clamp(zRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, zRotation);
        //roof.localRotation = Quaternion.Euler(xRotation, 0f, zRotation);
    }
}
