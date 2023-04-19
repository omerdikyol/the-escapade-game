using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static string currentSceneName;

    void Awake()
    {
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentSceneName);
    }
}
