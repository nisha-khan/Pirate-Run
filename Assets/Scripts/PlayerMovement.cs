using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Input controls;
    float direction = 0;
    public Rigidbody2D playerRB;
    public float speed = 400;
    public Animator animator;
    bool isFacingRight = true;
    bool isGrounded;
    public float jumpForce = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;
    int numberOfJumps = 0;
    bool isClimbing = false;
    public float climbSpeed = 5f; // Adjust the climbing speed as needed
    float originalGravityScale;

    private void Awake()
    {
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        controls = new Input();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx =>
        {
            if (!isClimbing)
            {
                Jump();
            }
        };

        controls.Land.Climb.performed += ctx =>
        {
          if (isClimbing)
    {
        // Handle climbing input using the new input system
        float verticalInput = ctx.ReadValue<float>();

        // Adjust the input values to move up and down correctly
        Vector2 climbDirection = new Vector2(0f, verticalInput) * climbSpeed;

        // Apply a climbing force to the rigidbody
        playerRB.velocity = climbDirection;
    }

        };
    }

    private void Start()
    {
        originalGravityScale = playerRB.gravityScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (!isClimbing)
        {
            playerRB.velocity = new Vector2(direction * speed * Time.deltaTime, playerRB.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(direction));

            if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("Jump");
        }
        else if (numberOfJumps == 1)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the character enters a ladder trigger zone
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            playerRB.velocity = Vector2.zero;
            playerRB.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the character exits a ladder trigger zone
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            playerRB.gravityScale = originalGravityScale;
        }
    }
}
