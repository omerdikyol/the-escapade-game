using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMinigameOnly : MonoBehaviour
{
    private Camera ourCamera;
    private void OnEnable()
    {
        ourCamera = GetComponent<Minigame>().ourCamera;
        GetComponent<Minigame>().DisableObjects();
    }
}