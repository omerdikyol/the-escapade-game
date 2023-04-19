using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public bool isEmpty;
    private Texture icon;
    public Texture currentTexture;
    [SerializeField] private GameObject incorrectDialogue;
    [SerializeField] private GameController gameController;

    [SerializeField] private bool isSearching = false;


    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
        icon = GetComponent<RawImage>().texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSearching)
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with any collider on 3D objects
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.collider.gameObject.GetComponent<Outline>() == null)
                //    hit.collider.gameObject.AddComponent<Outline>();
            }

            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if object is selectable, if not send an error and set isSearching false
                    GameObject clickedObject = hit.collider.gameObject;
                    Debug.Log(clickedObject);
                    Selectable selectable = clickedObject.GetComponent<Selectable>();
                    if (selectable != null)
                    {
                        if (selectable.validKey.Contains(gameController.GetSelectedItem()))
                        {
                            selectable.Select();
                        }
                        else
                        {
                            //Debug.Log("selectable but not the right one");
                            IncorrectDialogue();
                        }
                    }
                    else
                    {
                        //Debug.Log("not selectable");
                        IncorrectDialogue();
                    }

                    isSearching = false;
                    gameController.isSearching = false;
                }
            }
        }
    }

    public void Click()
    {
        if (!isEmpty && isSearching)
        {
            isSearching = false;
            gameController.isSearching = false;
            gameController.SetSelectedItem(null);
        }
        else if (!isEmpty)
        {
            // Write function to select object and make them interact with others
            // Instead of matching objects, match texture with object !!
            isSearching = true;
            gameController.isSearching = true;
            currentTexture = GetComponent<RawImage>().texture;
            gameController.SetSelectedItem(currentTexture);
            gameController.GetSelectedItem();
        }
    }

    public void SetIcon(Texture texture)
    {
        RawImage image = GetComponent<RawImage>();
        image.texture = texture;
        float alpha = (texture == null) ? 0f : 1f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    public void IncorrectDialogue()
    {
        incorrectDialogue.transform.position = GameObject.FindWithTag("Player").transform.position;
        incorrectDialogue.SetActive(true);

        StartCoroutine(DisableIncDialogue());
    }

    IEnumerator DisableIncDialogue()
    {
        yield return new WaitForSeconds(0.5f);

        incorrectDialogue.SetActive(false);
    }

    public void SetSearching(bool inp)
    {
        isSearching = inp;
    }
}
