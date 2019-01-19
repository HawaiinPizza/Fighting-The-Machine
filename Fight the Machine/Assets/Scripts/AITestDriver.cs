using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class AITestDriver : MonoBehaviour
{

    AIPath testAI;

    // Start is called before the first frame update
    void Start()
    {

        byte[] testAIMatrix = new byte[AIPath.numStates];
        //Debug.Log("Script Executed");


        for(int i = 0; i < AIPath.numStates; i++)
        {

            testAIMatrix[i] = (byte)(1 << Random.Range(0, 7));
            //set every BYTE in testAi to 1 and then shift every bit a random number between zero and seven to the left using bitwise operators
        }

        testAI = new AIPath(testAIMatrix);

    }

    // Update is called once per frame
    void Update()
    {
        //make mock states that you can set with different key stokes and then call the action in the ai
        //make the ai in the function a global variable

        gameState mock;

        if (Input.GetKeyDown(KeyCode.V))
        {
            mock = new gameState(0);
            testAI.actAI(mock);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            mock = new gameState(513);
            testAI.actAI(mock);
        }


        

    }
}
