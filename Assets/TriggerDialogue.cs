using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePrefab;
    private GameObject dialogueObject;
    [SerializeField] private string[] lines;
    [SerializeField]  private string charName;


    public void Dialogue()
    {
        dialogueObject = Instantiate(dialoguePrefab, new Vector2(0, -250), Quaternion.identity);
        dialogueObject.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        dialogueObject.SetActive(true);

        // Set Lines
        dialogueObject.GetComponent<Dialogue>().setLines(lines);

        // Set CharName 
        dialogueObject.GetComponent<Dialogue>().setCharacterName(charName);
    }

    public void OnTriggerEnter(Collider other)
    {
        Dialogue();
    }

    public void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
