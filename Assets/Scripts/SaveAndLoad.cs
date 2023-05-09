using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;
using StarterAssets;

public class SaveAndLoad : MonoBehaviour
{
    public SaveData saveData;

    public void SaveToFile()
    {
        saveData = new SaveData();
        string json = JsonUtility.ToJson(saveData);
        Debug.Log(json);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }

    public void LoadFile()
    {
        Debug.Log(Application.persistentDataPath + "/data.save");
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }
    }
}

[Serializable]
public class SaveData
{
    public string text = "bonjour";
    public Vector3 playerPosition = ThirdPersonController.instance.transform.position;
}
 