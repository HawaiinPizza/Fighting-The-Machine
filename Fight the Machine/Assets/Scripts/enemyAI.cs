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

    [Serializable]
    public class AIPath {
        private byte[] adjcencyMatrixPathing;
        public const int numStates = 131072;

        public AIPath(byte[] path) {
            adjcencyMatrixPathing = path;
        }

        public byte getByte(int index)
        {
            return adjcencyMatrixPathing[index];
        }

        public void setByte(int index, byte newValue)
        {
            adjcencyMatrixPathing[index] = newValue;
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
