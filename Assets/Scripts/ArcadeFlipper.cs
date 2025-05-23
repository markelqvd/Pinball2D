using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeFlipper : MonoBehaviour
{
    public bool isLeftFlipper = true;
    public float upAngle = 45f;
    public float downAngle = 0f;
    public float flipSpeed = 500f;

    private float targetAngle;
    private float lastAngle;
    public bool isMoving = false;

    void Update()
    {
        float currentZ = transform.eulerAngles.z;
        if (currentZ > 180) currentZ -= 360;

        // Detectar si el flipper se está moviendo
        isMoving = Mathf.Abs(currentZ - lastAngle) > 1f;  // 1 grado de tolerancia
        lastAngle = currentZ;

        // Entrada
        if ((isLeftFlipper && Input.GetKeyDown(KeyCode.Q)) || (!isLeftFlipper && Input.GetKeyDown(KeyCode.E)))
        {
            targetAngle = isLeftFlipper ? upAngle : -upAngle;
        }

        if ((isLeftFlipper && Input.GetKeyUp(KeyCode.Q)) || (!isLeftFlipper && Input.GetKeyUp(KeyCode.E)))
        {
            targetAngle = downAngle;
        }

        // Movimiento
        float newZ = Mathf.MoveTowards(currentZ, targetAngle, flipSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, newZ);
    }
}
