using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Look Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Clamping")]
    public float minY;
    public float maxY;

    private float rotX;
    private float rotY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            rotX += Input.GetAxis("Mouse X") * sensX;
            rotY += Input.GetAxis("Mouse Y") * sensY;
        }

        rotY = Mathf.Clamp(rotY, minY, maxY);

        transform.rotation = Quaternion.Euler(-rotY, rotX, 0);

        if (Input.GetKeyDown(KeyCode.T))
        {

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
