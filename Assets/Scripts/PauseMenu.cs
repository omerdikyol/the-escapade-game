using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void PauseGame()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        // if player is first person. cursor will be locked. so unlock it.
        if (!player.isThirdPerson)
        {
            Debug.Log("Cursor unlocked");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        AudioListener.volume = 0f;
        player.enabled = false;
    }

    public void ResumeGame()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        // if player is first person. cursor must be locked. so lock it.
        if (!player.isThirdPerson)
        {
            Debug.Log("Cursor locked");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        pauseMenuUI.SetActive(false);
        AudioListener.volume = 1f;
        player.enabled = true;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        Application.Quit();
    }

    public void BackToMenu()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        // if player is first person. cursor will be locked. so unlock it.
        if (!player.isThirdPerson)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
