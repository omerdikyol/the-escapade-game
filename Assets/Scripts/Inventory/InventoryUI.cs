using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject[] slots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(Collectible collectible)
    {
        foreach(GameObject slot in slots)
        {
            InventorySlot slotScript = slot.GetComponent<InventorySlot>();
            if(slotScript.isEmpty)
            {
                slotScript.isEmpty = false;
                slotScript.SetIcon(collectible.GetIcon());
                break;
            }
        }
    }

    public void RemoveItem()
    {
        foreach (GameObject slot in slots)
        {
            InventorySlot slotScript = slot.GetComponent<InventorySlot>();
            if (!slotScript.isEmpty && slotScript.GetComponent<RawImage>().texture == gameController.GetSelectedItem() )
            {
                Debug.Log("remove item");
                Debug.Log(gameController.GetSelectedItem());
                Debug.Log("remove item");
                slotScript.isEmpty = true;
                slotScript.SetIcon(null);
                gameController.SetSelectedItem(null);
                break;
            }
        }
    }
}
