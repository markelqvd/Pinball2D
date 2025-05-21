using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public float launchForce = 600f;
    private bool launched = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !launched)
        {
            ballRb.AddForce(Vector2.up * launchForce);
            //launched = true;
        }
    }
}
