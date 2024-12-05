using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float moveSpeed = 5f; // this determines the speed of my player
    public float jumpForce = 10f; // this will determine how high my player will jump
    private bool isGrounded = false; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from: " + gameObject.name);
        }
    }

    void Update()
    {
        if (rb == null) return;

        // for moving horizontally 
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //  this is for my player jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // this is a ground check for my player 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
