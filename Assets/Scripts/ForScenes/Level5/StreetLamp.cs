using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour
{
    public GameObject spotLight;

    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        // Get child spot light
        spotLight = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        // Turn on/off spot light
        spotLight.SetActive(!spotLight.activeSelf);

        // Turn on/off objects
        foreach (GameObject obj in objects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}
