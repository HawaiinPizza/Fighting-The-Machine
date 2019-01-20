using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class OpponentCharacter : MonoBehaviour
{

    private AIPath ai;
    private int health = 10000;
    private bool stunned = false, cooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    public int getHealth() { return health; }

    IEnumerator Action()
    {
        //get status
        yield return new WaitForSeconds(0.25f);
        //ai.actAI()
    }


}
