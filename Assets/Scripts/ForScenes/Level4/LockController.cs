using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public GameObject[] children;

    private Camera ourCamera;

    public string result = "";

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();

        foreach (GameObject child in children)
        {
            child.GetComponent<Lock>().enabled = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void CheckResult()
    {
        result = "";
        // add all indexes to result
        foreach (GameObject child in children)
        {
            result += child.GetComponent<Lock>().index.ToString();
        }

        if (result == "434432")
        {
            GetComponent<Minigame>().FinishSuccess();
        }
    }
}
