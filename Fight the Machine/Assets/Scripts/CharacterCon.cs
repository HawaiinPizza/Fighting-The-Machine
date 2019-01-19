using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCon : MonoBehaviour
{

    // MOVEMENT

    //This is the speed the character moves horzontally.
    float SpeedX = 5;

    // This is the speed the character jumps. 
    float SpeedYJ = 1;

    //This is teh amount of translation, a jump to become a fall.
    float FramesJ = 3;

    //This is the speed the character falls.
    float SpeedYF = 3;


    //ATTACK

    // If it's G, that its an attack on the ground. If it's a J, than it's an attack jumping.
    int GPunch = 4;
    int GKick = 3;
    int JPunch = 5;
    int JKick = 4;

    // Checks to see if in the air
    bool isAir;





    //This checks to see if the block
    bool isHigh;

    //Divides the usual damage, by this number.

    double blockDamage = 0.75;

    //Is the time the player gets stunned.
    int StunTime = 4;

    //Is a factor that applies to StunTime mulpitlivty, that lowers it.
    double StunScale = .80;


    // Is the factor that applys to all damages in a combo, that lowers it with repeated use.
    double DamageScale = .95;

    //Is the difference in frame, for two attacks to be counted as a combo.
    int ComboFrame = 4;




    // Update is called once per frame
    void Update()
    {
         //Vector3 p = transform.position;
        // This gets the input of the A and D, and returns
        // a value between -1 and 1. If A and D aren't being 
        // touch, it returns 0.
        float InputX = Input.GetAxis("Horizontal");

        float InputY = Input.GetAxis("Vertical");
        // This moves teh character, by InputX*SpeedX.
        float TransX = Math.Sign(InputX) * SpeedX;

        transform.Translate(TransX, 0, 0);


        
        

        if (Input.GetButton("Punch"))
        {
            PunAttack();
        }

        else if (Input.GetButton("Kick"))
        {
            Kickttack();
        }


    }

    // This jumps the player, which will eventually descedant.
    void CharJump(float TransY)
    {
        if (TransY > 0)
            //This  moves the character, by a factor of SpeedYJ in the air.
            for (int i = 0; i < FramesJ; i++)
            {

                transform.Translate(0, SpeedYJ, 0);
            }

        // Checks if the player is touchign the floor.

        isAir = true;
        // This moves the player odwn, by a factor of SpeedYF, till they're close to the floor
        while (isAir)
        {
            transform.Translate(0, SpeedYJ, 0);

        }
    }

            
        
    //Punch
    void PunAttack()
    {
        if (isAir)
        {
            // Attack enemy with Gpunch
        }
        else
        {
            // Attack enemy with Jpunch

        }


    }

    

    //Kick
    void Kickttack()
    {
        if (isAir)
        {
            // Attack enemy with GKick
        }
        else
        {
            // Attack enemy with JKick

        }


    }
       
}

