using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Car : MonoBehaviour
{

    private GameController gameController;
    public GameObject carBattery, sparkPlug, engine;

    public int carBatteryIndex, sparkPlugIndex, engineIndex;

    public UnityEvent success;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        carBatteryIndex = sparkPlugIndex = engineIndex = 0;
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
            carBatteryIndex = 1;
        }

        else if (selectedItem == "sparkPlug")
        {
            sparkPlug.SetActive(true);
            sparkPlugIndex = 1;
        }

        else if (selectedItem == "engine")
        {
            engine.SetActive(true);
            engineIndex = 1;
        }

        CheckSuccess();
    }

    public void CheckSuccess()
    {
        if (carBatteryIndex == 1 && sparkPlugIndex == 1 && engineIndex == 1)
        {
            Debug.Log("Success");
            success.Invoke();
        }
    }
}
