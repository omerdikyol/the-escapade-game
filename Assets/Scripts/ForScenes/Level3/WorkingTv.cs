using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingTv : MonoBehaviour
{
    private Camera ourCamera;

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Minigame>().EnableObjects();
            this.enabled = false;
        }
    }
}
