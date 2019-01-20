using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SaveDataTestDriver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            string s = "";
            for (int i = 0; i < Evolver.matchNum; i++)
            {
                byte[] matrix = new byte[AIPath.numStates];

                for (int j = 0; j < AIPath.numStates; j++)
                {
                    matrix[j] = (byte)(1 << Random.Range(1, 7));
                }

                metricAI metric = new metricAI();
                metric.roundsWon = Random.Range(0, 3);
                metric.matchTime = Random.Range(0, 10000);
                metric.health = Random.Range(-3000, 3000);

                bool completed = Random.Range(0, 2) == 0;

                SaveManager.saveData.path[i] = new AIPath(matrix);
                SaveManager.saveData.metric[i] = metric;
                SaveManager.saveData.completed[i] = completed;

                s = s + SaveManager.saveData.path[i].ToString() + "\t";
                s = s + SaveManager.saveData.metric[i] + "\t";
                s = s + SaveManager.saveData.completed[i] + "\n";
            }

            Debug.Log(s);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            SaveManager.SaveSaveData(1);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SaveManager.LoadSaveData(1);

            string s = "";
            for(int i = 0; i < Evolver.matchNum; i++)
            {
                s = s + SaveManager.saveData.path[i].ToString() + "\t";
                s = s + SaveManager.saveData.metric[i] + "\t";
                s = s + SaveManager.saveData.completed[i] + "\n";
            }

            Debug.Log(s);
        }
    }
}
