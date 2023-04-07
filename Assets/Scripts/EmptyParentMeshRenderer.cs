using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyParentMeshRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MeshRenderer>().enabled == false)
        {
            foreach( Transform child in transform)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
