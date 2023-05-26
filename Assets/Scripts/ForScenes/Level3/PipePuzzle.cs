using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    private Camera ourCamera;

    // solution array that holds the correct rotations for each pipe
    private int[] solution = new int[20] {
        0, 180, 90, 90, 90,
        0, 0, 180, 270, 90,
        0, 180, 0, 0, 180,
        90, 90, 0, 0, 90
    };

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
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
                List<GameObject> buttons = GetChildren();
                // If the collider belongs to this gameobject, handle the click
                foreach (GameObject go in buttons)
                {
                    if (hit.collider.gameObject == go)
                    {
                        // rotate the pipe 
                        go.transform.Rotate(0, 0, 90);
                    }
                }
            }

            if (CheckSolution()) // puzzle is solved
            {
                GetComponent<Minigame>().FinishSuccess();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Minigame>().EnableObjects();
            this.enabled = false;
        }
    }

    // Get all children of the pipe puzzle
    public List<GameObject> GetChildren()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            // if name has "Cube" in it, it is a pipe
            if (child.name.Contains("Cube"))
                children.Add(child.gameObject);
        }
        return children;
    }

    // Create a list of all the pipes and their rotations
    public List<int> GetRotations()
    {
        List<int> rotations = new List<int>();

        foreach (Transform child in transform)
        {
            if (!child.name.Contains("Cube"))
                continue;

            // if it's material name is pipe1, 0 degrees and 180 degrees are the same
            if (child.GetComponent<MeshRenderer>().material.name == "pipe1 (Instance)")
            {
                if ((int)child.transform.rotation.eulerAngles.z == 180 || (int)child.transform.rotation.eulerAngles.z == 0)
                {
                    rotations.Add(0);
                    continue;
                }
            }
            rotations.Add((int)child.transform.rotation.eulerAngles.z);
        }
        return rotations;
    }

    // Check if the solution is correct
    public bool CheckSolution()
    {
        List<int> rotations = GetRotations();

        for (int i = 0; i < rotations.Count; i++)
        {
            if (i == 1)
            {
                if (rotations[i] == 270)
                    rotations[i] = 180;
            }

            // skip solution[17] because it does not matter
            if (i == 17)
            {
                continue;
            }

            if (rotations[i] != solution[i])
            {
                return false;
            }
        }

        return true;
    }
}
