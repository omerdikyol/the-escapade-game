using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private string sceneName;

    void OnEnable()
    {
        LoadFromJson();
        Debug.Log("Loaded scene name: " + sceneName);
    }

    private void LoadFromJson()
    {
        using StreamReader reader = new StreamReader(Application.dataPath + "/save.json");
        string json = reader.ReadToEnd();
        string[] jsonSplit = json.Split(':');
        sceneName = jsonSplit[1].Replace("\"", "").Replace("}", "");

        Debug.Log("Load/Json: " + json);
        Debug.Log("Load/SceneName: " + sceneName);

        reader.Close();
    }

    public string GetSceneName()
    {
        return sceneName;
    }
}
