using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    public float smoothTime = 0.3f;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private AnimationClip animationClip;

    public void FocusObject()
    {
        StartCoroutine(Focus());
    }

    public IEnumerator Focus()
    {
        mainCamera.GetComponent<CameraController>().SetTarget(transform);

        yield return new WaitForSeconds(animationClip.length + 0.7f);

        mainCamera.GetComponent<CameraController>().SetTarget(GameObject.FindWithTag("Player").transform);
    }
}
