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
    [SerializeField] private bool isDestroyed;


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
        if(isDestroyed)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetPlayersPosition()
    {
        // Set position == player's position
        transform.position = GameObject.FindWithTag("Player").transform.position;
    }
}
