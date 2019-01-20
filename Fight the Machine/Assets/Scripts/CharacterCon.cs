using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CharacterCon : MonoBehaviour
{


    // Consants. speedx is teh speed of horzontal movement.
    // JumpVel is how powerful the jump is.
    // Gravity is teh acceleration that points to the -i hat direction.
    public float speedx, jumpVel, gravity;

    //This is a float to get input for the x-axis.
    private float moveInput;

    //Rigidbody. Important for anaimaton
    private Rigidbody2D rb;

    //Used to switch right to left.
    private bool facingRight=true;


    //See if the player is on the ground. I followed a tutoiral on it, and
    // it didn't really say why it worked.
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // See if the player can jump.
    bool canJump=true;






    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown("space") && isGrounded==true)
        {
            rb.AddForce(transform.up * jumpVel);
        
        }


    }


    // while the player isn't grounded, change their vertical velocity by a rate of gravity.
    private void FixedUpdate()
    {
        //Checks to see if isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

        //Gets input on the x-axis.
        moveInput = Input.GetAxis("Horz");

        //Moves the player horzonitally, by a factor of speedx.
        rb.velocity = new Vector2(moveInput * speedx, rb.velocity.y);


        Debug.Log(rb.velocity + " " + moveInput + " " + speedx + " " + canJump);

        //If the plaeyr is facing the right and is pressing the left, flip. If the other way around,
        // still flip.
        if (facingRight == false &&  moveInput > 0)
        {
            Flip();
        }
        if (facingRight == true &&  moveInput < 0)
        {
            Flip();
        }
    }

    //Flips the player to the other direction.
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}