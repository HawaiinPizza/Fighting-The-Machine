using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CharacterCon : MonoBehaviour
{


    public float speed, jumpForce, gravity;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight=true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    bool canJump=true;






    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (isGrounded == true)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
            transform.Translate(Vector3.down * gravity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump ==true)
        {

            rb.velocity = Vector2.up * jumpForce;
            canJump = false;
            transform.Translate(Vector3.down * gravity * Time.deltaTime);
        }


        

    }

    void fall()
    {

    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius);
        moveInput = Input.GetAxis("Horz");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            Debug.Log(rb.velocity + " " + moveInput + " " + speed + " " + canJump);

        if (facingRight == false &&  moveInput > 0)
        {
            Flip();
        }
        if (facingRight == true &&  moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}