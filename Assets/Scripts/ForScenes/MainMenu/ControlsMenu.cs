using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{
    public GameObject monitor;

    private void Start()
    {
    }

    private void OnEnable()
    {
        this.gameObject.SetActive(true);
    }

    void Update()
    {
    }

    public void BackButton()
    {
        monitor.GetComponent<Monitor>().enabled = false;
        this.gameObject.SetActive(false);

        GameObject.FindWithTag("MainCamera").GetComponent<Camera>().enabled = true;
        monitor.transform.GetChild(0).GetComponent<Camera>().enabled = false;
    }
}
