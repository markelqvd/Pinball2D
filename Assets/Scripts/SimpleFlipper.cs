using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlipper : MonoBehaviour
{
    public bool isLeftFlipper;
    public float maxAngle = 45f;
    public float speed = 300f;
    private float defaultAngle;

    void Start()
    {
        defaultAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        float targetAngle = defaultAngle;

        if (isLeftFlipper && Input.GetKey(KeyCode.Q))
        {
            targetAngle = defaultAngle + maxAngle;
        }
        else if (!isLeftFlipper && Input.GetKey(KeyCode.E))
        {
            targetAngle = defaultAngle - maxAngle;
        }

        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
