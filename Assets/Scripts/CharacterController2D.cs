using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public float smooth;
    Rigidbody2D rb2d;
    bool facingRight = true;
    bool grounded;
    public Collider2D groundCheck;
    public LayerMask groundLayer;
    public float jumpForce;
    Animator animator;
    int numberOfJumps = 1;
    int maxJumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 targetVelocity = new Vector2(x * speed, rb2d.velocity.y);

        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime * smooth);

        //if the input is moving the player right and the player is facing left...
        if (x > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

        animator.SetBool("Running", x != 0);
    }

    private void Update()
    {
        // Is the player touching the ground ?
        grounded = groundCheck.IsTouchingLayers(groundLayer);

        if (grounded)
        {
            numberOfJumps = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (grounded || numberOfJumps < maxJumps))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            numberOfJumps++;
        }
        
        animator.SetBool("Jumping", !grounded);

    }

    void Flip()
    {
        //Invert the facingRight variable
        facingRight = !facingRight;

        //Flip the Character
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }


}
