using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    private GameController gameController;
    public GameObject carBattery;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PutItem()
    {

        string selectedItem = gameController.selectedItem.name;

        if (selectedItem == "car_battery")
        {
            carBattery.SetActive(true);
        }


    }
}
