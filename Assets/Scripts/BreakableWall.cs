using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public float breakSpeedThreshold = 12f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.magnitude > breakSpeedThreshold)
            {
                Debug.Log("¡Pared rota!");
                Destroy(gameObject); // o animación, efecto, etc.
            }
        }
    }
}
