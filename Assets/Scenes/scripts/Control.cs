﻿using UnityEngine;

public class Control : MonoBehaviour
{

    public float speed;
    public float dashSpeed;
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
        dash();
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
        if (Input.GetKeyDown(KeyCode.R)) {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = Time.timeScale/2;
        }
        if (isGrounded)
        {
            horisontalMovement = transform.right * horisontal + transform.forward * vertical;
        }
        characterController.Move(horisontalMovement * speed * Time.deltaTime);
    }

    private void dash() {
        float horisontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dashDirection = transform.right * horisontal + transform.forward * vertical;
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime*10);
        }
    }
    
}
