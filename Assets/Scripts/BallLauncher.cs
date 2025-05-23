using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float launchForce = 600f;
    public float idleShakeForce = 0.1f;
    private Rigidbody2D ballInLauncher;

    void Update()
    {
        if (ballInLauncher != null)
        {
            // Aplica una pequeña fuerza cada frame para mantener la bola "activa"
            ballInLauncher.AddForce(Vector2.up * idleShakeForce, ForceMode2D.Force);

            // Si el jugador pulsa espacio, lanza la bola
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballInLauncher.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
                ballInLauncher = null;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ballInLauncher = other.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball") && ballInLauncher != null && other.GetComponent<Rigidbody2D>() == ballInLauncher)
        {
            ballInLauncher = null;
        }
    }
}
