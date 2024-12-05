using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 12f; // The force applied to the player when they bounce

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply an upward force to the player's Rigidbody2D
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
            }
        }
    }
}
