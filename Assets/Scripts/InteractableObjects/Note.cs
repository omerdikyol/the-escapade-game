using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject noteUI;
    [SerializeField] private GameObject interactCircle;
    private TMP_Text m_TextComponent;
    private GameObject child;
    [TextAreaAttribute] public string inputText;


    public void readNote()
    {
        // create note
        noteUI = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
        noteUI.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        noteUI.SetActive(true);
        
        // Get text object
        child = noteUI.transform.GetChild(0).gameObject;
        if(inputText != null)
        {
            // Write text if there is any
            m_TextComponent = child.GetComponent<TMP_Text>();
            m_TextComponent.text = inputText;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Close note 
            Destroy(noteUI);
            // Enable interaction
        }
    }
}
