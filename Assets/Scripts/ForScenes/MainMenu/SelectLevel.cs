using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public GameObject monitor;
    private void OnEnable()
    {
        this.gameObject.SetActive(true);
    }

    public void SelectButton(int num)
    {
        SceneManager.LoadScene("Scene" + num);
    }

    public void BackButton()
    {
        monitor.GetComponent<Monitor>().enabled = false;
        this.gameObject.SetActive(false);

        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().enabled = true;
        monitor.transform.GetChild(0).GetComponent<Camera>().enabled = false;
    }
}
