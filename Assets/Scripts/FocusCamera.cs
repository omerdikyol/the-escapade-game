using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    public float smoothTime = 0.3f;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private AnimationClip animationClip;

    private GameObject player;

    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void FocusObject()
    {
        StartCoroutine(Focus());
    }

    public IEnumerator Focus()
    {
        mainCamera.GetComponent<CameraController>().SetTarget(transform);
        player.GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(animationClip.length + 0.7f);

        mainCamera.GetComponent<CameraController>().SetTarget(GameObject.FindWithTag("Player").transform);
        player.GetComponent<PlayerController>().enabled = true;
    }
}
