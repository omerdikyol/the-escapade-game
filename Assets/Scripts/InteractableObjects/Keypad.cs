using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    private Transform interactCircle;
    private TMP_Text m_TextComponent;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject charHolder;
    [SerializeField] private string solution;
    private Camera ourCamera;

    private void OnEnable()
    {
        m_TextComponent = charHolder.GetComponentInChildren<TMP_Text>();
        ourCamera = GetComponent<Minigame>().ourCamera;

        GetComponent<Minigame>().DisableObjects();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = ourCamera.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with any collider on 3D objects
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // If the collider belongs to this gameobject, handle the click
                foreach (GameObject go in buttons)
                {
                    if (hit.collider.gameObject == go)
                    {
                        OnClick(go.name);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Minigame>().EnableObjects();
            this.enabled = false;
        }
    }

    void OnClick(string name)
    {
        if (int.TryParse(name, out _)) // if string is numeric ( pressed button is number )
        {
            if(m_TextComponent.text == "Enter" || m_TextComponent.text == "Incorrect")
            {
                m_TextComponent.text = name;
            }
            else
            {
                m_TextComponent.text += name;
            }
        }
        else // Clear or Enter
        {
            if(name == "Clear")
            {
                if (!string.IsNullOrEmpty(m_TextComponent.text) && int.TryParse(m_TextComponent.text, out _)) 
                    m_TextComponent.text = m_TextComponent.text.Remove(m_TextComponent.text.Length - 1); // remove last character
            }
            else
            {
                OnEnter(m_TextComponent.text);
            }
        }
    }


    void OnEnter(string input)
    {
        if(input == solution)
        {
            m_TextComponent.text = "Correct";
            //FinishSuccess();
        }
        else
        {
            m_TextComponent.text = "Incorrect";
        }
    }

    /*
    public void DisableObjects()
    {
        interactCircle.gameObject.SetActive(false);
        ui.SetActive(false);
        player.GetComponent<PlayerController>().enabled = false;
        mainCamera.GetComponent<CameraController>().DisableCamera();
        ourCamera.enabled = true;
        mainCamera.enabled = false;
    }

    public void EnableObjects()
    {
        interactCircle.gameObject.SetActive(true);
        ui.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        mainCamera.GetComponent<CameraController>().EnableCamera();
        mainCamera.enabled = true;
        ourCamera.enabled = false;
    }
    */
    /*
    public void FinishSuccess()
    {
        StartCoroutine(Finish());
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2);

        successful.Invoke();
        GetComponent<Minigame>().EnableObjects();
        this.enabled = false;
        // Our job is finished with that object
        interactCircle.gameObject.SetActive(false);
    }
    */
}
