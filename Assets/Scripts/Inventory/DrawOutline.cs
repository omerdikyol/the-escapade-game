using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOutline : MonoBehaviour
{
    private GameController gameController;

    /*// Start is called before the first frame update
    void Start()
    {
        GameObject gc = GameObject.FindWithTag("GameController");
        gameController = gc.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (gameController.isSearching)
        {
            gameObject.AddComponent<Outline>();
        }
    }

    private void OnMouseExit()
    {
        if (gameObject.GetComponent<Outline>() != null)
        {
            Destroy(gameObject.GetComponent<Outline>());
        }
    }*/
}
