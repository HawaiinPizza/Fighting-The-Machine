using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class loadProfile : MonoBehaviour
{
   public void load(int profile)
    {
        Debug.Log("load is executed");

        if(SaveManager.dataExists[profile - 1])
        {
            SaveManager.LoadSaveData(profile);
        }
        else
        {
            for(int i = 0; i < Evolver.matchNum; i++)
            {
                byte[] matrix = new byte[AIPath.numStates];

                for(int j = 0; j < AIPath.numStates; j++)
                {
                    matrix[j] = (byte)(1 << Random.Range(0, 8));
                }

                SaveManager.saveData.path[i] = new AIPath(matrix);
                SaveManager.saveData.metric[i] = new metricAI();
                SaveManager.saveData.completed[i] = false;

            }

            SaveManager.SaveSaveData(profile);
        }
    }
}
