using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selectable : MonoBehaviour
{
    public Texture validKey;
    public UnityEvent unityEvent;

    public void Select()
    {
        // if valid item is used, what is going to happen?
        unityEvent.Invoke(); // call all given functions
    }

    public void Aa()
    {
        Debug.Log("IAMTHEONEWHOKNOCKS");
    }
}
