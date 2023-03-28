using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Texture selectedItem;
    public bool isSearching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture GetSelectedItem()
    {
        Debug.Log(selectedItem);
        return selectedItem;
    }

    public void SetSelectedItem(Texture inp)
    {
        selectedItem = inp;
    }
}
