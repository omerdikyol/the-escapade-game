using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Texture selectedItem;
    public bool isSearching;
    [SerializeField] private GameObject selectInterface;

    public Animator fade;

    public bool firstPCursorEnabled = false;

    private void Awake()
    {
        fade = GameObject.Find("Fade").GetComponent<Animator>();
        fade.Play("Fade_End");
        StartCoroutine(WaitFade());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSearching == true)
        {
            selectInterface.SetActive(true);
        }
        else
        {
            selectInterface.SetActive(false);
        }

        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                GetComponent<PauseMenu>().PauseGame();
            }
            else
            {
                GetComponent<PauseMenu>().ResumeGame();
            }
        }

        // If player is first person, clicking ctrl will make the cursor appear
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            if (!player.isThirdPerson && Cursor.lockState == CursorLockMode.Locked)
            {
                firstPCursorEnabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (!player.isThirdPerson && Cursor.lockState == CursorLockMode.None)
            {
                firstPCursorEnabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public Texture GetSelectedItem()
    {
        return selectedItem;
    }

    public void SetSelectedItem(Texture inp)
    {
        selectedItem = inp;
    }

    IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(1);
        fade.gameObject.SetActive(false);
    }
}
