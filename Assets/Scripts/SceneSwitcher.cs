using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public string sceneName;

    public Animator fade;

    private void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(sceneName));
        }
    }

    IEnumerator LoadLevel(string levelName)
    {
        if (transition != null)
            transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        fade.gameObject.SetActive(true);
        fade.Play("Fade_Start");
        StartCoroutine(WaitFade());
        SceneManager.LoadScene(levelName);
    }


    public void NextSceneManually()
    {
        StartCoroutine(ManuallyLoadLevel(sceneName));
    }

    IEnumerator ManuallyLoadLevel(string levelName)
    {
        yield return new WaitForSeconds(transitionTime / 2);

        fade.gameObject.SetActive(true);
        fade.Play("Fade_Start");
        StartCoroutine(WaitFade());
        SceneManager.LoadScene(levelName);
    }

    IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(2);
        fade.gameObject.SetActive(false);
    }
}
