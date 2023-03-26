using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public bool isEmpty;
    private Texture icon;
    public Texture currentTexture;
    [SerializeField] private GameObject incorrectDialogue;

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
            // Maybe you can draw outline do hovered object

            if (Input.GetMouseButtonDown(0))
            {
                // Cast a ray from the camera to the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Check if the ray intersects with any collider on 3D objects
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if object is selectable, if not send an error and set isSearching false
                    Debug.Log(hit.collider.gameObject);
                    GameObject clickedObject = hit.collider.gameObject;
                    Selectable selectable = clickedObject.GetComponent<Selectable>();
                    if(selectable != null)
                    {
                        if (selectable.validKey == GetComponent<RawImage>().texture)
                        {
                            selectable.Select();
                        }
                        else
                        {
                            Debug.Log("selectable but not the right one");
                            IncorrectDialogue();
                        }
                    }
                    else
                    {
                        Debug.Log("not selectable");
                        IncorrectDialogue();
                    }

                    isSearching = false;
                }
            }
        }
    }

    public void Click()
    {
        if(!isEmpty)
        {
            Debug.Log("notempty");
            // Write function to select object and make them interact with others
            // Instead of matching objects, match texture with object !!
            isSearching = true;
            currentTexture = GetComponent<RawImage>().texture;

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
}
