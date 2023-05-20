using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    private Camera ourCamera;

    private float length = 0.02f;
    private float animationDuration = 0.3f;

    private string input = "";

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = ourCamera.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with any collider on 3D objects
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                // if it hits a key, create a animation for it
                if (hit.collider.gameObject.name.Contains("props_148key"))
                {
                    string name = hit.collider.gameObject.name;
                    // Get last 2 characters of the name
                    string key = name.Substring(name.Length - 2);
                    input += key;
                    // use translate to move the key down
                    hit.collider.gameObject.transform.Translate(Vector3.down * length);
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    StartCoroutine(wait(animationDuration, hit.collider.gameObject));
                }
            }
        }
    }

    IEnumerator wait(float waitTime, GameObject key)
    { //creating a function
        yield return new WaitForSeconds(waitTime); //tell unity to wait!!
        key.transform.Translate(Vector3.up * length);
        // Check if the correct order is inputted
        CheckInput();
    }

    /*
    keys:
        triangle - 19
        diamond - 29
        circle - 25
        star - 37
        heart - 34
        square - 42

    correct order:
        Triangle(C)
        Circle(D)
        Square(E)
        Star(F)
        Diamond(G)
        Heart(A)
        Diamond(C)
        Circle(D)
        Star(F)
        Square(E)
    */
    private void CheckInput()
    {
        if (input == "20")

        {
            GetComponent<Minigame>().EnableObjects();
            GetComponent<Minigame>().FinishSuccess();
        }

        if (input.Contains("19254237293429253742"))
        {
            GetComponent<Minigame>().FinishSuccess();
        }
        else if (input.Length > 50)
        {
            input = "";
        }
    }

}
