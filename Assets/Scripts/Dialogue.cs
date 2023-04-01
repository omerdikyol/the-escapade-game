using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TMP_Text dialogue;
    public string[] lines;
    public float textSpeed;

    private int index;

    private AudioSource dialogEffect;

    // Start is called before the first frame update
    void Start()
    {
        dialogEffect = GetComponent<AudioSource>();
        dialogue = gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        dialogue.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dialogEffect.enabled = false;
            if(dialogue.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogue.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (lines.Length > 0)
        {
            dialogEffect.enabled = true;
            // Type each character 1 by 1
            foreach (char c in lines[index].ToCharArray())
            {
                dialogue.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            dialogEffect.enabled = false;
        }

    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            dialogue.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void setLines(string[] newLines)
    {
        lines = newLines;
    }
}
