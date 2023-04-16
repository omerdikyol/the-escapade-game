using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool cameraEnabled = true;

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
        if (cameraEnabled)
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
                StartCoroutine(PerformRotation(newRotation));

                SetWalls(90);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
                StartCoroutine(PerformRotation(newRotation));

                SetWalls(-90);
            }
        }
    }

    public void SetTarget(Transform t)
    {
        smoothTime /= 100;
        target = t;
        smoothTime *= 100;
    }

    int mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }

    public void SetWalls(int angle)
    {
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

        int val = (angle > 0) ? 1 : -1;

        walls[(firstIndex + val + 4) % 4].enabled = true;
        walls[(secIndex + val + 4) % 4].enabled = true;

        // Change user rotation angle so rotation with mouse works correctly
        float newAngle = player.GetRotationAngle() + angle;
        // Clamp angle between 0 and 360
        newAngle = newAngle < 0 ? newAngle + 360 : newAngle;
        player.SetRotationAngle(newAngle % 360);
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

    public void DisableCamera()
    {
        cameraEnabled = false;
    }

    public void EnableCamera()
    {
        cameraEnabled = true;
    }

    public MeshRenderer[] GetWalls()
    {
        MeshRenderer[] walls = new MeshRenderer[]
        {
            leftBack.GetComponent<MeshRenderer>(),
            rightBack.GetComponent<MeshRenderer>(),
            rightFront.GetComponent<MeshRenderer>(),
            leftFront.GetComponent<MeshRenderer>()
        };
        return walls;
    }

    public void ChangeWalls(GameObject leftBack, GameObject rightBack, GameObject rightFront, GameObject leftFront)
    {
        this.leftBack = leftBack;
        this.rightBack = rightBack;
        this.rightFront = rightFront;
        this.leftFront = leftFront;
    }
}
