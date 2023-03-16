using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    // Movement
    [SerializeField] private float _speed = 1;
    //[SerializeField] private float _jumpForce = 200;

    // Animation
    private Animator animator;
    [SerializeField] private Vector3 moveDirection;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement of the player ( only forward )
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            transform.position += new Vector3(0.0001f, 0f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            transform.position -= new Vector3(0.00001f, 0f, 0f);
        }

        // Jump
        /*
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            _rb.AddForce(Vector3.up * _jumpForce);
        }
        */

        // Rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (Input.GetMouseButton(1)) // if right click is holding
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, -angle + 120, 0)); // rotate to the mouse
        }

        // Animation
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(moveDirection == Vector3.zero) // Idle
        {
            animator.SetFloat("Speed", 0);
        }
        else // walking
        {
            animator.SetFloat("Speed", 1);
        }

    }

}
