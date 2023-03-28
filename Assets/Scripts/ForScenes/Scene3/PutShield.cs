using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutShield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject dragon;
    [SerializeField] private GameController gameController;
    [SerializeField] private InventoryUI inventoryUI;
    private GameObject selectedObject = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shield()
    {

        string selectedName = gameController.GetSelectedItem().name;
        switch(selectedName)
        {
            case "shield1":
                selectedObject = shield;
                break;
            case "shield2":
                selectedObject = sword;
                break;
            case "shield3":
                selectedObject = dragon;
                break;
            default:
                selectedObject = null;
                break;
        }

        selectedObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        selectedObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        selectedObject.SetActive(true);
    }

    public string GetCurrentShield()
    {
        if(selectedObject == shield)
        {
            return "shield";
        }
        else if(selectedObject == sword)
        {
            return "sword";
        }
        else if (selectedObject == dragon)
        {
            return "dragon";
        }
        else
        {
            return "";
        }
    }
}
