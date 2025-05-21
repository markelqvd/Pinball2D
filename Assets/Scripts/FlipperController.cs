using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public HingeJoint2D hinge;
    public bool isLeft;
    public float pressSpeed = 1000f;
    public float releaseSpeed = -1000f;

    void Update()
    {
        JointMotor2D motor = hinge.motor;

        if (isLeft)
        {
            motor.motorSpeed = Input.GetKey(KeyCode.E) ? pressSpeed : releaseSpeed;
        }
        else
        {
            motor.motorSpeed = Input.GetKey(KeyCode.RightArrow) ? -pressSpeed : -releaseSpeed;
        }

        hinge.motor = motor;
    }
}
