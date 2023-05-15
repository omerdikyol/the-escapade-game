using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    private string sceneName;

    public static List<string> unlockedLevels;

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (!unlockedLevels.Contains(sceneName))
        {
            unlockedLevels.Add(sceneName);
        }
        SaveToJson();
    }

    private void SaveToJson()
    {
        string path = Application.dataPath + "/save.json";
        string persistentDataPath = Application.persistentDataPath + "/save.json";

        Debug.Log("Save/Path: " + path);
        string json = "{\"sceneName\":\"" + sceneName + "\"}";
        Debug.Log("Save/Json: " + json);

        using StreamWriter writer = new StreamWriter(path, false);
        writer.Write(json);
        writer.Close();

    }
}
