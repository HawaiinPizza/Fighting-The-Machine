using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts
{

    [Serializable]
    public class SaveData
    {
        public AIPath[] path = new AIPath[Evolver.matchNum];
        public metricAI[] metric = new metricAI[Evolver.matchNum];
        public bool[] completed = new bool[Evolver.matchNum];
    }

    public class SaveManager
    {
        public static int matchesSinceEvo = 0;
        public static SaveData saveData = new SaveData();
        public static bool[] dataExists = profileStatus();

        public static void LoadSaveData(int profile)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            string fileName = Path.Combine(Application.persistentDataPath, "save_data/profile" + profile + ".dat");
            using (FileStream fileStream = File.Open(fileName, FileMode.Open))
            {
                saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
            }

            Debug.Log(fileName);
        }

        public static void SaveSaveData(int profile)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            string fileName = Path.Combine(Application.persistentDataPath, "save_data/profile" + profile + ".dat");
            using (FileStream fileStream = File.Open(fileName, FileMode.Open))
            {
                binaryFormatter.Serialize(fileStream, saveData);
            }

            Debug.Log(fileName);
        }

        private static bool[] profileStatus()
        {
            bool[] dExists = new bool[3];
            for(int i = 1; i <= 3; i++)
            {
                long l = new System.IO.FileInfo(Path.Combine(Application.persistentDataPath, "save_data/profile" + i + ".dat")).Length;
                dExists[i-1] = l != 0;
            }

            return dExists;
        }

    }


}