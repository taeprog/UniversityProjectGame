using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Control : MonoBehaviour
{

    public float speed;
    public float jumpHight = 3f;
    public float gravity=-9.81f;

    public float groundDistance = 0.4f;
    public Transform groundCheck;
    
    public LayerMask groundMask;

    private CharacterController characterController;

    private Vector3 velocity;
    private Boolean isGrounded;

    private Boolean changingGravity = false;
    private Boolean rotated = true;
    private float rotationDirection = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotated)
        {
            applyGravity();
        }
        if (!changingGravity)
        {   
            characterMove();
        }
        else {
            rotateGravity();
        }
        
    }
    private void applyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Vector3 gravityVelocity = Vector3.Scale(velocity, transform.up);
        Boolean gravityVelocityAplied = gravityVelocity.x < 0 || gravityVelocity.y < 0 || gravityVelocity.z < 0;
        if (isGrounded && gravityVelocityAplied)
        {
            velocity = transform.up * 0f;
        }
        velocity += transform.up * gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void characterMove(){

        float horisontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded) {
            int forward = vertical == 0 ? 0 : 1;
            velocity = transform.up * Mathf.Sqrt(jumpHight * -2f * gravity)+transform.forward*(speed)*forward;
        }
        if (isGrounded)
        {
            Vector3 move = transform.right * horisontal + transform.forward * vertical;
            characterController.Move(move * speed * Time.deltaTime);
        }
        else {
            if (Input.GetKeyDown(KeyCode.Q)) {
                changingGravity = true;
                rotated = false;
                rotationDirection = -1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                changingGravity = true;
                rotated = false;
                rotationDirection = 1;
            }
            //добавить вращение 180 deg на C
        }
    }

    private void rotateGravity() {
        if (!rotated) {
            Vector3 normalForward = Utils.normalizeDirection(transform.forward);
            transform.Rotate(normalForward, 90f * rotationDirection, Space.World);
            rotationDirection = 0;
            rotated = true;
            gravity *= 3;
        }
        if (isGrounded)
        {
            gravity /= 3;
            changingGravity = false;
        }

    }


    public Boolean isGravityChanging() {
        return changingGravity;
    }
    
}
