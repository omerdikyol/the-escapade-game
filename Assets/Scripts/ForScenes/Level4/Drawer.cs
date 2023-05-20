using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    private Camera ourCamera;
    public bool drawer1Open = false;
    public bool drawer2Open = false;
    public bool drawer3Open = false;

    public bool drawer3Unlocked = false;

    public GameObject drawer3LockedDialogue, sparkPlugDialogue;

    public Animator myAnimator;
    private InventoryUI inventoryUI;

    // Collectible items
    public Collectible greenBook, sparkPlug;


    // Start is called before the first frame update
    void Start()
    {
        inventoryUI = GameObject.FindWithTag("Inventory").GetComponent<InventoryUI>();
    }

    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = ourCamera.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with any collider on 3D objects
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.name == "drawer1")
                {
                    if (drawer1Open == false)
                    {
                        Debug.Log("open1");
                        myAnimator.Play("open1");
                        drawer1Open = true;
                    }
                    else
                    {
                        myAnimator.Play("close1");
                        drawer1Open = false;
                    }
                }
                else if (hit.collider.gameObject.name == "drawer2")
                {
                    if (drawer2Open == false)
                    {
                        myAnimator.Play("open2");
                        drawer2Open = true;
                    }
                    else
                    {
                        myAnimator.Play("close2");
                        drawer2Open = false;
                    }
                }
                else if (hit.collider.gameObject.name == "drawer3")
                {
                    if (drawer3Unlocked == false)
                    {
                        drawer3LockedDialogue.GetComponent<TriggerDialogue>().Dialogue();
                        return;
                    }
                    if (drawer3Open == false)
                    {
                        myAnimator.Play("open3");
                        drawer3Open = true;
                    }
                    else
                    {
                        myAnimator.Play("close3");
                        drawer3Open = false;
                    }
                }

                else if (hit.collider.gameObject.name == "Green Book")
                {
                    // Add green book to inventory
                    inventoryUI.AddItem(greenBook);
                    // Destroy the green book
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.gameObject.name == "SparkPlug")
                {
                    // Add spark plug to inventory
                    inventoryUI.AddItem(sparkPlug);
                    sparkPlugDialogue.GetComponent<TriggerDialogue>().Dialogue();
                    // Destroy the spark plug
                    Destroy(hit.collider.gameObject);
                    GetComponent<Minigame>().FinishSuccess();
                }
            }
        }
    }

    public void UnlockDrawer3()
    {
        drawer3Unlocked = true;
    }
}
