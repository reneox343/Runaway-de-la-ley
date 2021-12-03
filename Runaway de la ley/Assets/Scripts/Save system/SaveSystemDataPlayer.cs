using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveSystemDataPlayer 
{
    public static void savePlayerData(int level, int money, bool[] revolverUpgrades, bool[] revolversUpgrades, bool[] shootgunUpgrades, bool[] trowablesUpgrades)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream fileStream = new FileStream(path,FileMode.Create);
        PlayerData data = new PlayerData(level, money, revolverUpgrades, revolversUpgrades, shootgunUpgrades, trowablesUpgrades);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerData loadPlayerData() {

        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return data;
        }
        else 
        {

            Debug.LogError("Safe File Not Found in " + path);
            return null;

        }

    }
}
