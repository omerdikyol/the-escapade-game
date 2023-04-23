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
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        AudioListener.volume = 0f;
        player.enabled = false;
    }

    public void ResumeGame()
    {
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
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
