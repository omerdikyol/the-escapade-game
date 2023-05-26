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
        noteUI = Instantiate(noteUIPrefab, new Vector2(0, 0), Quaternion.identity);
        noteUI.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        noteUI.SetActive(true);
        if (noteAudio != null)
            noteAudio.enabled = true;

        int childCount = noteUI.transform.childCount;
        // Get text object
        if (childCount > 3)
        {
            child = noteUI.transform.GetChild(3).gameObject;
            if (inputText != null)
            {
                // Write text if there is any
                m_TextComponent = child.GetComponent<TextMeshProUGUI>();
                m_TextComponent.text = inputText;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Close note 
            if (noteUI != null)
            {
                Destroy(noteUI);
                if (noteAudio != null)
                    noteAudio.enabled = false;
            }
        }
    }
}
