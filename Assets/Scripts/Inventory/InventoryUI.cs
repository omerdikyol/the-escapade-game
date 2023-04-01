using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioSource equipEffect;
    [SerializeField] private AudioSource unequipEffect;
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
                equipEffect.Play();
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
                Debug.Log(gameController.GetSelectedItem());
                slotScript.isEmpty = true;
                slotScript.SetIcon(null);
                gameController.SetSelectedItem(null);
                unequipEffect.Play();
                break;
            }
        }
    }
}
