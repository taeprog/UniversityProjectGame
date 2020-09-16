using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotation : MonoBehaviour
{
    public GroundChecker groundChecker;
    public float rotationSpeed=0.8f;

    private bool rotationEnabled = true;
    private float rotationDirection = 0;
    private float timeCount = 0.0f;
    private float angleRotated = 0.0f;
    private float rotationMultiplyer = 1f;
    private Vector3 axis;
    private enum RotationDirection {
        RightDirection,
        LeftDirection
    }
    void Update()
    {
        input();
        if (rotationEnabled) {
            rotateGravity();
        }
    }

    private void input() {
        if (!groundChecker.isGrounded()) {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                enableRotation(RotationDirection.LeftDirection);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                enableRotation(RotationDirection.RightDirection);
            }
        }
    }

    private void enableRotation(RotationDirection direction) {
        if (rotationDirection == 0.0f) {
            axis = Utils.normalizeDirection(transform.forward);
            if (direction == RotationDirection.LeftDirection)
            {
                rotationDirection = -1;
            }
            else
            {
                rotationDirection = 1;
            }
        }
        
        if (rotationEnabled) {
            rotationMultiplyer = 2f;
        }
        rotationEnabled = true;
    }

    private void rotateGravity()
    {
        float maxAngle = 90f * rotationMultiplyer;
       
        if (angleRotated >= maxAngle)
        {
            disableRotation();
            resetValues();
        }
        else
        {
            float angle = Mathf.Lerp(0f, maxAngle - angleRotated, timeCount);
            angleRotated += angle;
            transform.Rotate(axis, angle * rotationDirection, Space.World);
            timeCount += Time.deltaTime*rotationSpeed;
        }
    }
    private void disableRotation() {
        rotationEnabled = false;
    }

    private void resetValues() {
        rotationDirection = 0;
        timeCount = 0.0f;
        angleRotated = 0.0f;
        rotationMultiplyer = 1f;
    }
}
