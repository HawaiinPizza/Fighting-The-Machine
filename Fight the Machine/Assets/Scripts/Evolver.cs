using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class Evolver
    {

        public const int matchNum = 20;
        public const double ascendingPercent = 0.5;
        public const int numCrossPol = matchNum * 1000;
        public const int numMutate = matchNum * 500;

        public static AIPath[] evolveAI(AIPath[] paths, metricAI[] metrics)
        {
            System.Random rand = new System.Random();

            //Sort the batch
            AIPath tempPath; metricAI tempMetric;

            for(int i = 1, j; i < matchNum - 1; i++)
            {
                tempPath = paths[i];
                tempMetric = metrics[i];
                j = i - 1;

                while(j>=0 && compareMetric(metrics[j], tempMetric) < 1) //if metric[j] is shittier than tempMetric
                {
                    paths[j + 1] = paths[j];
                    metrics[j + 1] = metrics[j];
                    j--;
                }

                paths[j + 1] = tempPath;
                metrics[j + 1] = tempMetric;

            }

            //Kill bad members
            for(int i = matchNum; i > (int)(matchNum*(1.0 - ascendingPercent)); i--)
            {
                paths[i] = null;
            }

            //Cross-polinate
            for(int i = 0; i < numCrossPol; i++)
            {
                int path1 = rand.Next(0, (int)(matchNum * ascendingPercent) - 1);
                int path2 = rand.Next(0, (int)(matchNum * ascendingPercent) - 2);
                if(path2 >= path1) { path2++; }

                int trait = rand.Next(0, AIPath.numStates - 1);

                byte temp = paths[path1].getByte(trait);
                paths[path1].setByte(trait, paths[path2].getByte(trait));
                paths[path2].setByte(trait, temp);
            }

            //Mutate
            for(int i = 0; i < numMutate; i++)
            {
                int path = rand.Next(0, (int)(matchNum * ascendingPercent) - 1);
                int trait = rand.Next(0, AIPath.numStates - 1);
                byte temp = (byte)(1 << (rand.Next(0, 7)));
                paths[path].setByte(trait, temp);
            }

            //Generate new AIPaths
            for (int i = matchNum; i > (int)(matchNum * (1.0 - ascendingPercent)); i--)
            {
                byte[] AIMatrix = new byte[AIPath.numStates];

                for (int j = 0; j < AIPath.numStates; j++)
                {

                    AIMatrix[j] = (byte)(1 << UnityEngine.Random.Range(0, 7));
                }

                paths[i] = new AIPath(AIMatrix);
            }

            //Randomize Order of Batch
            for(int i = matchNum - 1; i > 0; i--)
            {
                int k = rand.Next(0, matchNum - 1);
                AIPath temp = paths[k];
                paths[k] = paths[i];
                paths[i] = temp;
            }

            return paths;
        }

        private static short compareMetric(metricAI a, metricAI b)
        {
            if(a.roundsWon > b.roundsWon) { return 1; }
            else if(a.roundsWon < b.roundsWon) { return -1; }
            else
            {
                if(a.matchTime > b.matchTime) { return 1; }
                else if(a.matchTime < b.matchTime) { return -1; }
                else
                {
                    if(a.health > b.health) { return 1; }
                    else if(a.health < b.health) { return -1; }
                    else { return 0; }
                }
            }
        }
    }

    [Serializable]
    public class metricAI
    {
        public int roundsWon = 0;
        public int matchTime = 0;
        public int health = 0;
    }
}
