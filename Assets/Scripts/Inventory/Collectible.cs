using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private Texture icon;
    [SerializeField] private string itemName;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture GetIcon()
    {
        return icon;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
