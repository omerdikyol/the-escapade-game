using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MailBoxNote : MonoBehaviour
{
    public GameObject interactCircle;

    public UnityEvent events;

    public bool call = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactCircle.activeSelf == false && call)
        {
            StartCoroutine(Wait());
            call = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        events.Invoke();
        this.enabled = false;
    }
}
