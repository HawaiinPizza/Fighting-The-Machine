using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterCon : MonoBehaviour
{

    // Time paramters

    float Cooldownpause = 2;
    int CooldownScale = 2;

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

    bool canhit = true;
    bool canmove = true;

    bool isBlock = false;

    float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }






    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    
    }

    private void Update()
    {
       
    }

    public void moveXaxis(float Direction)
    {
        if (canmove)
        {
            //Moves the player horzonitally, by a factor of speedx.
             rb.velocity = new Vector2(Direction * speedx, rb.velocity.y);
             Debug.Log(rb.velocity);

            if (Direction > 0 && !facingRight)
            {
                Flip();
            }

            if (Direction < 0 && facingRight)
            {
                Flip();
            }
        } 
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
    }

    public void jump()
    {
            if (canmove)
            {
                if (isGrounded == true)
                {
                    Debug.Log("I'm grounded");
                    rb.AddForce(transform.up * jumpVel);
                }
            }
            else
            {
                rb.AddForce(transform.up * 0);
            }
    }
    // while the player isn't grounded, change their vertical velocity by a rate of gravity.
    private void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.J))
        {
            punch();
            Debug.Log("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            kick();
            Debug.Log("KICK");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Block(true,true);
                Debug.Log("BLOCK");
            }
            else
            {
                Block(false,true);
            }

        }
        else if (Input.GetKeyUp("l"))
        {
                Block(false,false);

        }
        //Checks to see if isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

        //Gets input on the x-axis.
        moveInput = Input.GetAxis("Horz");

        moveXaxis(moveInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
           jump();
            Debug.Log("JUMP");
        }

    }

        private IEnumerator HitDelay()
    {
        canhit = false;

        yield return new WaitForSeconds(Cooldownpause);

        canhit = true;
    }
    public void punch()
    {


        if (canhit == true)
        {
            StartCoroutine("HitDelay");
            Debug.Log("PUNCH");


        }

    }

    public void kick()
    {

        if (canhit == true)
        {
            StartCoroutine("HitDelay");
            Debug.Log("Kick");


        }
    }

    public void Block(bool highBlock, bool isBlock)
    {

        if (isBlock)
        {
            if (isGrounded)
            {
                if (highBlock)
                {

                    Debug.Log("HIGH");

                }
                else
                {

                    Debug.Log("Low");
                }
                canmove = false;
                canhit = false;
            }
        }
        else if (!isBlock)
        {

            canmove = true;
            canhit = true;
        }
    }

    //Flips the player to the other direction.
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
