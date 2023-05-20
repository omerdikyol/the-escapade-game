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

    private GameObject firstPersonUI;

    public GameObject firstToThirdTeleporter;

    public GameObject thirdToFirstTeleporter;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
        firstPersonUI = GameObject.Find("FirstPersonControls");
        thirdPCam = GameObject.FindWithTag("MainCamera");
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

        thirdPCam.GetComponent<Camera>().enabled = true;
        thirdPCam.GetComponent<CameraController>().enabled = true;
        thirdPCam.GetComponent<AudioListener>().enabled = true;

        thirdPPlayer.SetActive(true);
        thirdPPlayer.GetComponent<PlayerController>().isInteracting = false;

        firstPPlayer.SetActive(false);
        firstPersonUI.GetComponent<TextMeshProUGUI>().enabled = false;
        // Enable Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Teleport the thirdPPlayer to the teleporter's position
        if (firstToThirdTeleporter != null)
        {
            thirdPPlayer.transform.position = firstToThirdTeleporter.transform.position;
        }

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

        thirdPCam.GetComponent<Camera>().enabled = false;
        thirdPCam.GetComponent<CameraController>().enabled = false;
        thirdPCam.GetComponent<AudioListener>().enabled = false;

        // Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Teleport the firstPPlayer to the teleporter's position
        if (thirdToFirstTeleporter != null)
        {
            firstPPlayer.transform.position = thirdToFirstTeleporter.transform.position;
        }

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
