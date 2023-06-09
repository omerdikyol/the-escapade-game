using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePrefab;
    private GameObject dialogueObject;
    [SerializeField] private string[] lines;
    [SerializeField] private bool isDestroyed;

    public void Dialogue()
    {
        dialogueObject = Instantiate(dialoguePrefab, new Vector2(0, -250), Quaternion.identity);
        dialogueObject.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        dialogueObject.SetActive(true);

        // Set Lines
        dialogueObject.GetComponent<Dialogue>().setLines(lines);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            Dialogue();
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (isDestroyed)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SetPlayersPosition()
    {
        // Set position == player's position
        transform.position = GameObject.FindWithTag("Player").transform.position;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
