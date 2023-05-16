using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstThirdPersonTransition : MonoBehaviour
{

    public GameObject thirdPPlayer;

    public GameObject firstPPlayer;

    public GameObject thirdPCam;

    private Animator fade;

    public UnityEvent events;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
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

        Debug.Log("First to Third person");
        Debug.Log("flag1");
        thirdPCam.SetActive(true);
        Debug.Log("flag2");
        thirdPPlayer.SetActive(true);
        thirdPPlayer.GetComponent<PlayerController>().isInteracting = false;
        Debug.Log("flag3");
        firstPPlayer.SetActive(false);
        // Enable Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("flag4");
        events.Invoke();
        Debug.Log("flag9");
        StartCoroutine(WaitFade2());

    }

    IEnumerator ThirdToFirst()
    {
        yield return new WaitForSeconds(0.95f);
        RemoveUIText();
        // Third to First person
        Debug.Log("Third to First person");
        firstPPlayer.SetActive(true);
        Debug.Log("flag5");
        thirdPPlayer.GetComponent<PlayerController>().isInteracting = false;
        thirdPPlayer.SetActive(false);
        Debug.Log("flag6");
        thirdPCam.SetActive(false);
        Debug.Log("flag7");
        // Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("flag8");
        events.Invoke();
        Debug.Log("flag9");
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
