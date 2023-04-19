using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeWalls : MonoBehaviour
{
    private GameObject player;
    public GameObject leftBack;
    public GameObject rightBack;
    public GameObject rightFront;
    public GameObject leftFront;

    private GameObject floor;

    private GameObject room;

    private Camera cam;
    private float currentAngle = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = Camera.main;
        floor = transform.parent.gameObject.transform.GetChild(0).gameObject;
        room = transform.parent.gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (room.activeSelf == false)
                room.SetActive(true);
            if (floor.activeSelf == true)
                floor.SetActive(false);

            currentAngle = player.GetComponent<PlayerController>().GetRotationAngle();
            switch (currentAngle)
            {
                case 30: // left back and left front are visible
                    leftBack.GetComponent<MeshRenderer>().enabled = true;
                    leftFront.GetComponent<MeshRenderer>().enabled = true;
                    rightBack.GetComponent<MeshRenderer>().enabled = false;
                    rightFront.GetComponent<MeshRenderer>().enabled = false;
                    break;
                case 120: // left back and right back are visible
                    leftBack.GetComponent<MeshRenderer>().enabled = true;
                    rightBack.GetComponent<MeshRenderer>().enabled = true;
                    leftFront.GetComponent<MeshRenderer>().enabled = false;
                    rightFront.GetComponent<MeshRenderer>().enabled = false;
                    break;
                case 210: // right back and right front are visible
                    rightBack.GetComponent<MeshRenderer>().enabled = true;
                    rightFront.GetComponent<MeshRenderer>().enabled = true;
                    leftBack.GetComponent<MeshRenderer>().enabled = false;
                    leftFront.GetComponent<MeshRenderer>().enabled = false;
                    break;
                case 300: // right front and left front are visible
                    rightFront.GetComponent<MeshRenderer>().enabled = true;
                    leftFront.GetComponent<MeshRenderer>().enabled = true;
                    leftBack.GetComponent<MeshRenderer>().enabled = false;
                    rightBack.GetComponent<MeshRenderer>().enabled = false;
                    break;
                default:
                    break;
            }

            cam.GetComponent<CameraController>().ChangeWalls(leftBack, rightBack, rightFront, leftFront);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // When the player exits the trigger, the walls are set to invisible and only floor is visible in the room
            room.SetActive(false);
            floor.SetActive(true);
        }
    }
}
