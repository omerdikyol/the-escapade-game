using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour
{
    public Camera ourCamera;
    public Behaviour objectScript;
    public UnityEvent successful;
    private Transform interactCircle;

    // do we have to hide the player and ui?
    public bool hidePlayer = true;
    public bool hideUI = true;
    public bool isInteractable = true;

    // disable objects
    private GameObject ui;
    private GameObject player;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindWithTag("Player");
        ui = GameObject.FindWithTag("UI");
        if (isInteractable)
            interactCircle = transform.Find("InteractCircle");
    }

    private void OnEnable()
    {
        mainCamera = Camera.main;
        player = GameObject.FindWithTag("Player");
        ui = GameObject.FindWithTag("UI");
        if (isInteractable)
            interactCircle = transform.Find("InteractCircle");
    }

    // Update is called once per frame
    void Update()
    {
        if (ourCamera.enabled)
        {
            player.GetComponent<PlayerController>().isInteracting = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            EnableObjects();
            objectScript.enabled = false;
        }
    }

    public void DisableObjects()
    {
        player.GetComponent<PlayerController>().moveDirection.y = 0; // Stop movement of player
        player.GetComponent<PlayerController>().isInteracting = true;
        player.GetComponent<AudioSource>().enabled = false; // Disable Footstep Sound Effect
        mainCamera.GetComponent<CameraController>().DisableCamera();
        ourCamera.enabled = true;
        mainCamera.enabled = false;

        if (hideUI)
            ui.SetActive(false);
        else
        {
            // Remove all interact labels
            GameObject[] interactLabels = GameObject.FindGameObjectsWithTag("InteractLabel");
            foreach (GameObject label in interactLabels)
            {
                Destroy(label);
            }
        }

        // make player invisible
        if (hidePlayer)
            player.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    }

    public void EnableObjects()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerController>().isInteracting = false;
        mainCamera.GetComponent<CameraController>().EnableCamera();
        mainCamera.enabled = true;
        ourCamera.enabled = false;

        if (hideUI)
            ui.SetActive(true);

        // make player visible
        if (hidePlayer)
            player.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    }

    public void FinishSuccess()
    {
        StartCoroutine(Finish());
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2);

        successful.Invoke();
        EnableObjects();
        this.enabled = false;
        objectScript.enabled = false;
        // Our job is finished with that object
        if (isInteractable)
            interactCircle.gameObject.SetActive(false);
    }
}
