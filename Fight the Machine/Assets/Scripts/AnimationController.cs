using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Animator>().Play("jump");
            Debug.Log("Player has jumped.");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("idle");
        }
    }
}
