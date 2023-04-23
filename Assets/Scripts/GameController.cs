using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Texture selectedItem;
    public bool isSearching;
    [SerializeField] private GameObject selectInterface;

    public Animator fade;

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
