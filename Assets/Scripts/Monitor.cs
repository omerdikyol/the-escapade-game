using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
