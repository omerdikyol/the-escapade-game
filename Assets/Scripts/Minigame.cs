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
        interactCircle = transform.Find("InteractCircle");
    }

    // Update is called once per frame
    void Update()
    {

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

        // make player invisible
        if (hidePlayer)
            player.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

        // Get canvas and add text TMP to it
        GameObject canvas = GameObject.Find("Canvas");
        GameObject text = Instantiate(Resources.Load("Prefabs/Text") as GameObject);
        text.transform.SetParent(canvas.transform, false);
        text.GetComponent<TextMeshProUGUI>().text = "You fixed the computer!";
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

        // Get canvas and remove text TMP from it
        GameObject canvas = GameObject.Find("Canvas");
        GameObject text = GameObject.Find("Text");
        Destroy(text);
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
        interactCircle.gameObject.SetActive(false);
    }
}
