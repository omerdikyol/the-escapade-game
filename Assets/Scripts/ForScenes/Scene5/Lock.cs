using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public string[] values;
    public GameObject[] children;

    public Camera ourCamera;

    public int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        children = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }

        children[0].GetComponent<TMP_Text>().text = values[index];
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
                if (hit.collider.gameObject == children[2])
                {
                    // change the value of the current index
                    index = (index + 1) % values.Length;
                    // change the value of the text
                    children[0].GetComponent<TMP_Text>().text = values[index];

                    // Check the result
                    GetComponentInParent<LockController>().CheckResult();
                }
            }
        }
    }
}
