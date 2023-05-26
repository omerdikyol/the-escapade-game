using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    private string sceneName;
    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        SaveToJson();
    }

    private void SaveToJson()
    {
        string path = Application.dataPath + "/save.json";
        string persistentDataPath = Application.persistentDataPath + "/save.json";

        string json = "{\"sceneName\":\"" + sceneName + "\"}";

        using StreamWriter writer = new StreamWriter(path, false);
        writer.Write(json);
        writer.Close();

    }
}
