using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OpenDoor()
    {
        animator.Play("doorOpen");
    }

    public void CloseDoor()
    {
        animator.Play("doorClose");
    }
}
