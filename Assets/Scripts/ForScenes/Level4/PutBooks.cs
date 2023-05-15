using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBooks : MonoBehaviour
{
    private Camera ourCamera;

    public string holder1, holder2, holder3;

    public GameObject bookHolder1, bookHolder2, bookHolder3;

    private GameController gameController;

    private InventoryUI inventoryUI;

    public Collectible greenBook, purpleBook;

    public bool isTimeout = false;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        inventoryUI = GameObject.FindWithTag("Inventory").GetComponent<InventoryUI>();

        holder1 = "";
        holder2 = "";
        holder3 = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTimeout)
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = ourCamera.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with any collider on 3D objects
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("On Update: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Purple Book")
                {
                    // Add purple book to inventory
                    inventoryUI.AddItem(hit.collider.gameObject.GetComponent<Collectible>());
                    // Disable the purple book
                    hit.collider.gameObject.SetActive(false);

                    // Get the holder's name
                    string holderName = hit.collider.gameObject.transform.parent.gameObject.name;
                    // Get the holder's number
                    int holderNum = int.Parse(holderName.Substring(holderName.Length - 1));

                    RemoveBook(holderNum);
                }

                else if (hit.collider.gameObject.name == "Green Book")
                {
                    // Add green book to inventory
                    inventoryUI.AddItem(hit.collider.gameObject.GetComponent<Collectible>());
                    // Disable the green book
                    hit.collider.gameObject.SetActive(false);

                    // Get the holder's name
                    string holderName = hit.collider.gameObject.transform.parent.gameObject.name;
                    // Get the holder's number
                    int holderNum = int.Parse(holderName.Substring(holderName.Length - 1));

                    RemoveBook(holderNum);
                }
            }
        }
    }

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
    }

    public void PutBook(int num)
    {
        Debug.Log("PutBook: " + num);
        // get selected item's name
        string selectedItem = gameController.GetSelectedItem().name;
        string result = (selectedItem == "greenBook") ? "green" : "purple";
        GameObject holderObject = null;
        switch (num)
        {
            case 1:
                holder1 = result;
                holderObject = bookHolder1;

                break;
            case 2:
                holder2 = result;
                holderObject = bookHolder2;

                break;
            case 3:
                holder3 = result;
                holderObject = bookHolder3;
                break;
        }

        Debug.Log("(PutBook) Result: " + result);


        // Put book object to the holder
        if (result == "purple")
            holderObject.transform.GetChild(0).gameObject.SetActive(true);
        else
            holderObject.transform.GetChild(1).gameObject.SetActive(true);

        // Disable collider of the holder
        holderObject.GetComponent<MeshCollider>().enabled = false;

        Debug.Log("(PutBook) Holders:" + holder1 + " " + holder2 + " " + holder3);

        // Put a timeout
        StartCoroutine(Timeout());

        if (CheckSuccess() == 1)
        {
            Debug.Log("Success");
            GetComponent<Minigame>().FinishSuccess();
        }
    }

    public void RemoveBook(int num)
    {
        Debug.Log("RemoveBook: " + num);
        GameObject holderObject = null;
        switch (num)
        {
            case 1:
                holder1 = "";
                holderObject = bookHolder1;
                break;
            case 2:
                holder2 = "";
                holderObject = bookHolder2;
                break;
            case 3:
                holder3 = "";
                holderObject = bookHolder3;
                break;
        }

        // Add item to inventory
        if (holderObject.transform.GetChild(0).gameObject.activeSelf)
            inventoryUI.AddItem(purpleBook);

        else if (holderObject.transform.GetChild(1).gameObject.activeSelf)
            inventoryUI.AddItem(greenBook);

        // Remove book object from the holder
        holderObject.transform.GetChild(0).gameObject.SetActive(false);
        holderObject.transform.GetChild(1).gameObject.SetActive(false);

        // Enable collider of the holder
        holderObject.GetComponent<MeshCollider>().enabled = true;

        Debug.Log("(RemoveBook) Holders:" + holder1 + " " + holder2 + " " + holder3);
    }

    public int CheckSuccess()
    {
        if (holder1 == "green" && holder2 == "green" && holder3 == "purple")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    IEnumerator Timeout()
    {
        isTimeout = true;
        yield return new WaitForSeconds(1);
        isTimeout = false;
    }
}
