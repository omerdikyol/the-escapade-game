using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FirstThirdPersonTransition : MonoBehaviour
{

    public GameObject thirdPPlayer;

    public GameObject firstPPlayer;

    public GameObject thirdPCam;

    private Animator fade;

    public UnityEvent events;

    public GameObject firstPersonUI;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
        firstPersonUI = GameObject.Find("FirstPersonControls");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Write a function that will teleport the thirdPPlayer to the given object's position
    public void Transition()
    {
        fade.gameObject.SetActive(true);
        fade.Play("Fade_Both");
        if (firstPPlayer.activeSelf)
        {
            StartCoroutine(FirstToThird());
        }
        else
        {
            StartCoroutine(ThirdToFirst());
        }
    }

    IEnumerator FirstToThird()
    {
        yield return new WaitForSeconds(0.95f);
        RemoveUIText();
        thirdPCam.SetActive(true);
        thirdPPlayer.SetActive(true);
        thirdPPlayer.GetComponent<PlayerController>().isInteracting = false;

        firstPPlayer.SetActive(false);
        firstPersonUI.GetComponent<TextMeshProUGUI>().enabled = false;
        // Enable Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        events.Invoke();

        StartCoroutine(WaitFade2());

    }

    IEnumerator ThirdToFirst()
    {
        yield return new WaitForSeconds(0.95f);
        RemoveUIText();
        firstPPlayer.SetActive(true);
        firstPersonUI.GetComponent<TextMeshProUGUI>().enabled = true;

        thirdPPlayer.GetComponent<PlayerController>().isInteracting = false;
        thirdPPlayer.SetActive(false);
        thirdPCam.SetActive(false);

        // Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        events.Invoke();

        StartCoroutine(WaitFade2());

    }

    IEnumerator WaitFade2()
    {
        yield return new WaitForSeconds(2);
        fade.gameObject.SetActive(false);
    }

    void RemoveUIText()
    {
        // Find all gameobjects with tag "InteractLabel" and remove them
        GameObject[] interactLabels = GameObject.FindGameObjectsWithTag("InteractLabel");
        foreach (GameObject label in interactLabels)
        {
            Destroy(label);
        }
    }
}
