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
        if (direction == RotationDirection.LeftDirection)
        {
            rotationDirection = -1;
        }
        else 
        {
            rotationDirection = 1;
        }
        rotationEnabled = true;
    }

    private void rotateGravity()
    {
        Vector3 normalForward = Utils.normalizeDirection(transform.forward);
        if (angleRotated >= 90f)
        {
            disableRotation();
            resetValues();
        }
        else
        {
            float angle = Mathf.Lerp(0f, 90f - angleRotated, timeCount);
            angleRotated += angle;
            transform.Rotate(normalForward, angle * rotationDirection, Space.World);
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
    }
}
