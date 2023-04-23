using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject player;

    private Animator fade;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fade = GameObject.Find("Fade").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Write a function that will teleport the player to the given object's position
    public void Teleport()
    {
        fade.gameObject.SetActive(true);
        fade.Play("Fade_Both");
        StartCoroutine(WaitFade());
    }

    IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(0.95f);
        player.transform.position = this.transform.position;
        StartCoroutine(WaitFade2());
    }

    IEnumerator WaitFade2()
    {
        yield return new WaitForSeconds(2);
        fade.gameObject.SetActive(false);
    }
}
