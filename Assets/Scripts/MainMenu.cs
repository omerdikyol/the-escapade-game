using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private Camera ourCamera;

    public GameObject monitor;
    private void OnEnable()
    {
        ourCamera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        ourCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = ourCamera.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with any collider on 3D objects
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.name == "PlayButton")
                {
                    StartGame();
                }
                else if (hit.transform.gameObject.name == "OptionsButton")
                {
                    Options();
                }
                else if (hit.transform.gameObject.name == "QuitButton")
                {
                    Quit();
                }
            }

        }
    }

    public void StartGame()
    {
        string savedScene = PlayerPrefs.GetString("SavedScene");
        if (savedScene != "")
        {
            SceneManager.LoadScene(savedScene);
        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    public void Options()
    {
        Camera.main.GetComponent<Camera>().enabled = false;
        monitor.transform.GetChild(0).GetComponent<Camera>().enabled = true;
        monitor.GetComponent<Monitor>().enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
