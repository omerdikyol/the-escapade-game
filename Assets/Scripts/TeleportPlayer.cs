using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPlayer : MonoBehaviour
{
    private GameObject player;

    private Animator fade;

    public UnityEvent events;

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
        events.Invoke();
        StartCoroutine(WaitFade2());
    }

    IEnumerator WaitFade2()
    {
        yield return new WaitForSeconds(2);
        fade.gameObject.SetActive(false);
    }
}
