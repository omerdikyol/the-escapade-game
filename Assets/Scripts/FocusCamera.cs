using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    public float smoothTime = 0.3f;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private AnimationClip animationClip;
    [SerializeField] private float animationLength = 0f;

    public void FocusObject()
    {
        StartCoroutine(Focus());
    }

    public IEnumerator Focus()
    {
        mainCamera.GetComponent<CameraController>().SetTarget(transform);

        float usedLength = (animationClip == null) ? animationLength : animationClip.length;

        yield return new WaitForSeconds(usedLength + 0.7f);

        mainCamera.GetComponent<CameraController>().SetTarget(GameObject.FindWithTag("Player").transform);
    }
}
