using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Statue : MonoBehaviour
{
    public GameObject leftWingObject;
    public GameObject rightWingObject;
    public GameObject torchObject;

    public bool cauldron = false;

    public UnityEvent OnStatueFinished;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPiece()
    {
        Texture currentItem = gameController.GetSelectedItem();
        // Get the name of the texture
        string piece = currentItem.name;

        if (piece == "left_wing")
        {
            leftWingObject.SetActive(true);
        }
        else if (piece == "right_wing")
        {
            rightWingObject.SetActive(true);
        }
        else if (piece == "torch")
        {
            torchObject.SetActive(true);
        }
        else if (piece == "cauldron")
        {
            cauldron = true;
        }

        // Check if the statue is finished
        if (leftWingObject.activeSelf && rightWingObject.activeSelf && torchObject.activeSelf && cauldron)
        {
            OnStatueFinished.Invoke();
        }
    }
}
