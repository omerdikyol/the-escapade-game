using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Extractor : MonoBehaviour
{
    public bool honey = false;
    public bool tenax = false;

    public UnityEvent OnExtractorReady;

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

    public void AddIngredient()
    {
        Texture currentItem = gameController.GetSelectedItem();
        // Get the name of the texture
        string ingredient = currentItem.name;
        if (ingredient == "honey_jar")
        {
            honey = true;
        }
        else if (ingredient == "phormium_tenax")
        {
            tenax = true;
        }

        // Check if the extractor is ready
        if (honey && tenax)
        {
            OnExtractorReady.Invoke();
        }
    }
}
