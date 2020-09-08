using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Control playerBody;

    private float xRotation = 0f;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
        
       
    void Update () {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
       
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if (!playerBody.isGravityChanging()) {
            Vector3 up = Utils.normalizeDirection(transform.up);
            playerBody.transform.Rotate(up, mouseX, Space.World);
        }
        
    }
}
