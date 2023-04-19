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
        pauseMenuUI.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        player.enabled = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        player.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
