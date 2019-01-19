using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CharacterCon : MonoBehaviour
{


    public float speed, jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight=true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horz");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            Debug.Log(rb.velocity + " " + moveInput + " " + speed);

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