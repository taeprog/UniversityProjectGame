using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class Control : MonoBehaviour
{

    public float speed;
    public float jumpHight = 3f;
    public float gravity=-9.81f;
    public GroundChecker groundChecker;
  

    private CharacterController characterController;

    private float verticalVelocity =0.0f;
    private Vector3 horisontalMovement;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        applyGravity();
        characterMove();     
    }

    private void applyGravity()
    {
        isGrounded = groundChecker.isGrounded();
        if (isGrounded && verticalVelocity<0)
        {
            verticalVelocity = -2f;
        }
        else {
            verticalVelocity += gravity * Time.deltaTime;
            
        }
        characterController.Move(Utils.normalizeDirection(transform.up) * verticalVelocity * Time.deltaTime);
    }

    private void characterMove(){

        float horisontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded) {
            verticalVelocity = Mathf.Sqrt(jumpHight * -2f * gravity);
        }
        if (isGrounded)
        {
            horisontalMovement = transform.right * horisontal + transform.forward * vertical;
        }
        characterController.Move(horisontalMovement * speed * Time.deltaTime);
    }

    
}
