using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    private Boolean grounded;

    void Update() {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }


    public Boolean isGrounded() {
        return grounded;
    }
}
