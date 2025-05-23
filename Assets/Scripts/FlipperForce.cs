using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperForce : MonoBehaviour
{
    public float forceMultiplier = 10f;
    private ArcadeFlipper flipper;

    void Start()
    {
        flipper = GetComponentInParent<ArcadeFlipper>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!flipper.isMoving) return; // Si el flipper no se mueve, no aplicar fuerza

        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                Vector2 direction = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(direction * forceMultiplier, ForceMode2D.Impulse);
            }
        }
    }
}
