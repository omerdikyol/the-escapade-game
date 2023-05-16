using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject noteUIPrefab;
    private GameObject noteUI;
    private TMP_Text m_TextComponent;
    private GameObject child;
    [TextAreaAttribute] public string inputText;
    [SerializeField] private AudioSource noteAudio;


    public void ReadNote()
    {
        //Debug.Log(inputText);
        // create note
        noteUI = Instantiate(noteUIPrefab, new Vector2(0, 0), Quaternion.identity);
        noteUI.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        noteUI.SetActive(true);
        if (noteAudio != null)
            noteAudio.enabled = true;

        // Get text object
        child = noteUI.transform.GetChild(3).gameObject;
        if (inputText != null)
        {
            // Write text if there is any
            m_TextComponent = child.GetComponent<TMP_Text>();
            //Debug.Log(m_TextComponent.text);
            m_TextComponent.text = inputText;
            //m_TextComponent.font = myFont;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Close note 
            Destroy(noteUI);
            if (noteAudio != null)
                noteAudio.enabled = false;
        }
    }
}
