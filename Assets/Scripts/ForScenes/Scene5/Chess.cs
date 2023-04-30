using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    private Camera ourCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
