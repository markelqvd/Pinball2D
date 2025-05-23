using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float extraForce = 5f;
    public Color hitColor = Color.red;
    private Color originalColor;
    private SpriteRenderer sr;

    public int scoreValue = 100;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Rebote extra
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 bounceDir = collision.contacts[0].normal * -1;
            rb.AddForce(bounceDir * extraForce, ForceMode2D.Impulse);

            // Color flash
            sr.color = hitColor;
            Invoke(nameof(ResetColor), 0.1f);

            ScoreManager.instance.AddScore(scoreValue);
        }
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }
}
