using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(sceneName));
        }
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }


    public void NextSceneManually()
    {
        StartCoroutine(ManuallyLoadLevel(sceneName));
    }

    IEnumerator ManuallyLoadLevel(string levelName)
    {
        yield return new WaitForSeconds(transitionTime/2);

        SceneManager.LoadScene(levelName);
    }
}
