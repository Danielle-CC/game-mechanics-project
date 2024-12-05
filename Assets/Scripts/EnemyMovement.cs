using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Walking speed
    public Transform groundCheck; // Point to check for ground
    public LayerMask groundLayer; // Layer for ground detection
    public float patrolDistance = 5f; // Maximum distance to patrol

    private Vector2 startPosition; // Starting position of the enemy
    private int patrolDirection = 1; // 1 = moving right, -1 = moving left
    private bool isGrounded = true;

    private void Start()
    {
        startPosition = transform.position; // Save the starting position
    }

    private void Update()
    {
        // Check if the enemy is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (!isGrounded)
        {
            // If no ground, flip direction
            FlipDirection();
        }

        // Move in the current patrol direction
        transform.Translate(Vector2.right * patrolDirection * moveSpeed * Time.deltaTime);

        // Check if the enemy has exceeded patrol distance
        if (Vector2.Distance(startPosition, transform.position) >= patrolDistance)
        {
            FlipDirection();
        }
    }

    private void FlipDirection()
    {
        patrolDirection *= -1; // Reverse direction
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); // Flip sprite
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with the player!");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Call the player's damage logic
            }
        }
    }
}
