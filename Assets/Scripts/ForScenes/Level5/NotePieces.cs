using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotePieces : MonoBehaviour
{
    public GameObject[] notePieces;

    public GameObject finalNote;

    public bool notePiece1 = false;
    public bool notePiece2 = false;
    public bool notePiece3 = false;

    public UnityEvent OnNoteFinished;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPiece()
    {
        Texture currentItem = gameController.GetSelectedItem();
        // Get the name of the texture
        string piece = currentItem.name;
        if (piece == "notepiece1")
        {
            notePieces[0].SetActive(true);
        }
        else if (piece == "notepiece2")
        {
            notePieces[1].SetActive(true);
        }
        else if (piece == "notepiece3")
        {
            notePieces[2].SetActive(true);
        }

        // Check if the note is finished
        if (notePieces[0].activeSelf && notePieces[1].activeSelf && notePieces[2].activeSelf)
        {
            finalNote.SetActive(true);
            foreach (GameObject notePiece in notePieces)
            {
                notePiece.SetActive(false);
            }
            OnNoteFinished.Invoke();
        }

    }
}
