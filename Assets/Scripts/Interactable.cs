using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public bool isInRange;
    public KeyCode interactKey;
    private GameObject interactUI;
    private Vector3 objectPosOnCamera;
    private string parentName;
    [SerializeField] private string interactName;
    public UnityEvent interactAction;
    private TMP_Text m_TextComponent;
    public bool onWaiting = false;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        parentName = transform.parent.gameObject.name;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get active camera and convert world position to screen position.
        // Find valid camera to cast ray from
        Camera[] cameras = FindObjectsOfType<Camera>();
        foreach (Camera camera in cameras)
        {
            if (camera.GetComponent<Camera>().enabled)
            {
                objectPosOnCamera = camera.WorldToScreenPoint(transform.position);
                break;
            }
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (isInRange && !player.isInteracting)
        {
            // Put Interact button on the object.
            if (interactUI != null)
                interactUI.transform.position = new Vector2(objectPosOnCamera.x, objectPosOnCamera.y + 20);

            if (Input.GetKeyDown(interactKey) && !onWaiting)
            {
                if (player.isThirdPerson)
                    player.GetComponent<PlayerController>().Interact();
                interactAction.Invoke(); // call given functions on UnityEvent object
                StartCoroutine(Wait());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            // Create interact label, put it into canvas and set active
            interactUI = Instantiate(prefab, new Vector2(objectPosOnCamera.x, objectPosOnCamera.y + 30), Quaternion.identity);
            interactUI.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            interactUI.SetActive(true);

            // add object name to label
            m_TextComponent = interactUI.GetComponent<TMP_Text>();
            m_TextComponent.text = (interactName == "") ? parentName + "\n" + m_TextComponent.text : interactName + "\n" + m_TextComponent.text;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;

            // Delete interact label
            Destroy(interactUI);
        }
    }

    private void OnDisable()
    {
        Destroy(interactUI);
        onWaiting = false;
    }

    IEnumerator Wait()
    {
        // put 2 seconds delay between interacts to avoid spam.
        onWaiting = true;
        yield return new WaitForSeconds(2); //Wait 2 second
        onWaiting = false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void ResetState()
    {
        player.isInteracting = false;
        this.isInRange = false;
    }
}
