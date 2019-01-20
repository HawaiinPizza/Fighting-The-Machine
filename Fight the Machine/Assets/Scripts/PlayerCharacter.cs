using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class PlayerCharacter : MonoBehaviour
{
    GameObject tracker;
    
    private int health = 10000;
    
    CharacterCon controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = new CharacterCon(); // Move Around
    }

    // Update is called once per frame
    public float moveSpeed;
    public float jumpPower;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector2.up * jumpPower);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Move Left
            controller.moveXaxis(-1);
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //Move Right
            controller.moveXaxis(1);
        }

       /* if (Input.GetKeyDown(KeyCode.W))
        {
            controller.jump();
            anim.Play("jump");
        }
        */

        if (Input.GetKeyDown(KeyCode.J))
        {
            //Punch
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            //Kick
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            //High Block
        }
        else if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.S))
        {
            //Low Block
        }

    }

    public int getHealth() { return health; }

    public Vector2 getPosition()
    {
        return tracker.transform.position;
    }

    private void Awake()
    {
        GameObject tracker = new GameObject();
    }

}
