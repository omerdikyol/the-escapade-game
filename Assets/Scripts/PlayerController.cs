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
    [SerializeField] private Rigidbody _rb;

 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Movement of the player ( only forward )
        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = transform.forward * _speed;
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
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 120, 0)); // rotate to the mouse
        }
    }
}
