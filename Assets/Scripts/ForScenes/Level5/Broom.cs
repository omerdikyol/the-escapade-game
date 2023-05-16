using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Broom : MonoBehaviour
{
    public GameObject dirt1;
    public GameObject dirt2;
    public GameObject dirt3;

    private int flag1 = 0;
    private int flag2 = 0;
    private int flag3 = 0;

    private InventoryUI inventory;

    public GameObject dialogue;

    public UnityEvent dirt1Cleaned;
    public UnityEvent dirt2Cleaned;
    public UnityEvent dirt3Cleaned;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag1 == 1 && flag2 == 1 && flag3 == 1)
        {
            dialogue.GetComponent<TriggerDialogue>().Dialogue();
            inventory.RemoveItem();
            this.gameObject.SetActive(false);
        }
    }

    public void SetFlag(int flag)
    {
        if (flag == 1)
        {
            dirt1Cleaned.Invoke();
            flag1 = 1;
        }
        else if (flag == 2)
        {
            dirt2Cleaned.Invoke();
            flag2 = 1;
        }
        else if (flag == 3)
        {
            dirt3Cleaned.Invoke();
            flag3 = 1;
        }
    }
}
