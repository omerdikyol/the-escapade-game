using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;

    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10;

    private Vector3 velocity = Vector3.zero;

    // Walls
    [SerializeField] private GameObject leftBack;
    [SerializeField] private GameObject rightBack;
    [SerializeField] private GameObject rightFront;
    [SerializeField] private GameObject leftFront;

    private PlayerController player;

    // Rotation
    private float timeCount = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // follow the player
        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);

        // zoom in and zoom out
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;

        
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);

        // min max for orthographicSize
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 3.0f, 7.45f);

        // Change the rotation
        if (Input.GetKeyDown(KeyCode.R))
        {
            Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
            StartCoroutine(PerformRotation(newRotation));

            SetWalls();
        }
    }

    public void SetTarget(Transform t)
    {
        smoothTime /= 100;
        target = t;
        smoothTime *= 100;
    }

    public void SetWalls()
    {
        // direction == 1 : T pressed, direction == -1: R pressed 
        MeshRenderer[] walls = new MeshRenderer[]
        {
            leftBack.GetComponent<MeshRenderer>(),
            rightBack.GetComponent<MeshRenderer>(),
            rightFront.GetComponent<MeshRenderer>(),
            leftFront.GetComponent<MeshRenderer>()
        };
        // Get visible walls
        MeshRenderer[] enabledWalls = walls.Where(c => c.enabled).ToArray();
        int firstIndex = Array.IndexOf(walls, enabledWalls[0]);
        int secIndex = Array.IndexOf(walls, enabledWalls[1]);

        walls[firstIndex].enabled = false;
        walls[secIndex].enabled = false;

        walls[(firstIndex - 1 + 4) % 4].enabled = true;
        walls[(secIndex - 1 + 4) % 4].enabled = true;

        // Change user rotation angle so rotation with mouse works correctly
        player.SetRotationAngle((player.GetRotationAngle() - 90) % 360);
    }

    IEnumerator PerformRotation(Quaternion targetRotation)
    {
        float progress = 0f;
        float speed = 0.5f;
        while (progress < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, progress);
            progress += Time.deltaTime * speed;
            if (progress <= 1f)
            {
                yield return null;
            }
        }
    }
}
