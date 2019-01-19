using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{

    public class gameState
    {
        private uint bitFlag;

        

       /* public gameState(
            bool p_stunned,
            bool p_frameCooldown,
            bool p_inAir,
            bool p_mBlock,
            bool p_lBlock,
            bool p_punch,
            bool p_kick,
            bool p_engaging,
            bool p_disengaging,
            bool o_inAir,
            bool o_mBlock,
            bool o_lBlock,
            bool o_punch,
            bool o_kick,
            bool o_engaging,
            bool o_disengaging,
            bool inRange
            ) {

            bitFlag = 0;

            //Sets the bit flags to each boolean
            if (p_stunned) {
                bitFlag = bitFlag | (1 << 0);
            }
            if (p_frameCooldown)
            { 
                bitFlag = bitFlag | (1 << 1);
            }
            if (p_inAir)
            {
                bitFlag = bitFlag | (1 << 2);
            }
            if (p_mBlock)
            {
                bitFlag = bitFlag | (1 << 3);
            }
            if (p_lBlock)
            {
                bitFlag = bitFlag | (1 << 4);
            }
            if (p_punch)
            {
                bitFlag = bitFlag | (1 << 5);
            }
            if (p_kick)
            {
                bitFlag = bitFlag | (1 << 6);
            }
            if (p_engaging)
            {
                bitFlag = bitFlag | (1 << 7);
            }
            if (p_disengaging)
            {
                bitFlag = bitFlag | (1 << 8);
            }
            if (o_inAir)
            {
                bitFlag = bitFlag | (1 << 9);
            }
            if (o_mBlock)
            {
                bitFlag = bitFlag | (1 << 10);
            }
            if (o_lBlock)
            {
                bitFlag = bitFlag | (1 << 11);
            }
            if (o_punch)
            {
                bitFlag = bitFlag | (1 << 12);
            }
            if (o_kick)
            {
                bitFlag = bitFlag | (1 << 13);
            }
            if (o_engaging)
            {
                bitFlag = bitFlag | (1 << 14);
            }
            if (o_disengaging)
            {
                bitFlag = bitFlag | (1 << 15);
            }
            if (inRange)
            {
                bitFlag = bitFlag | (1 << 16);
            }

        }*/

        public gameState(uint id)
        {
            //Bit 0 - Player Stun
            //Bit 1 - Player Frame Cooldown
            //Bit 2 - Player In Air
            //Bit 3 - Player High Block
            //Bit 4 - Player Low Block
            //Bit 5 - Player Punch
            //Bit 6 - Player Kick
            //Bit 7 - Player Engaging
            //Bit 8 - Player Disengaging
            //Bit 9 - Opponent In Air
            //Bit 10 - Opponent High Block
            //Bit 11 - Opponent Low Block
            //Bit 12 - Opponent Punch
            //Bit 13 - Opponent Kick
            //Bit 14 - Opponent Engaging
            //Bit 15 - Opponent Disengaging
            //Bit 16 - In Range

            bitFlag = id;
        }

        public uint getBitFlag() {
            return bitFlag;
        }

        public String toString()
        {
            String str = "ID: " + bitFlag;

            return str;
        }
    }

    public class AIPath {
        private byte[] adjcencyMatrixPathing;
        public const uint numStates = 131072;

        public AIPath(byte[] path) {
            adjcencyMatrixPathing = path;
        }

        public void actAI(gameState currentState) {
            uint index = currentState.getBitFlag();
            byte toDo = adjcencyMatrixPathing[index];

            if(((toDo >> 0) & 1) == 1)
            {
                //Move Right
                Debug.Log("Move Right");
            }
            else if(((toDo >> 1) & 1) == 1)
            {
                //Move Left
                Debug.Log("Move Left");
            }
            else if (((toDo >> 2) & 1) == 1)
            {
                //Jump
                Debug.Log("Jump");
            }
            else if (((toDo >> 3) & 1) == 1)
            {
                //Punch
                Debug.Log("Punch");
            }
            else if (((toDo >> 4) & 1) == 1)
            {
                //Kick
                Debug.Log("Kick");
            }
            else if (((toDo >> 5) & 1) == 1)
            {
                //High Block
                Debug.Log("High Block");
            }
            else if (((toDo >> 6) & 1) == 1)
            {
                //Low Block
                Debug.Log("Low Block");
            }
            else if (((toDo >> 7) & 1) == 1)
            {
                //Inaction
                Debug.Log("Inaction");
            }
        }
    }
}
