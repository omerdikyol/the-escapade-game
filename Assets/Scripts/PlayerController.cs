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
    private Rigidbody rb;
    [SerializeField] private bool isInteracting;
    private AudioSource walkingAudio;

    // Rotation
    public float rotationAngle = 120f;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isInteracting = false;
        walkingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isInteracting)
        {
            // Movement of the player ( only forward )
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
                transform.position += new Vector3(0.0001f, 0f, 0f);
                walkingAudio.enabled = true; // Enable Footstep Sound Effect
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                transform.position -= new Vector3(0.00001f, 0f, 0f);
            }

            // Rotation
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            if (Input.GetMouseButton(1)) // if right click is holding
            {
                // Reset Momentum
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                transform.localRotation = Quaternion.Euler(new Vector3(0, -angle + rotationAngle, 0)); // rotate to the mouse
            }
        }

        // Animation
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveDirection == Vector3.zero) // Idle
        {
            animator.SetFloat("Speed", 0);
            walkingAudio.enabled = false; // Disable Footstep Sound Effect
        }
        else if (moveDirection.y > 0) // walking Forward
        {
            animator.SetFloat("Speed", 1);
            walkingAudio.enabled = true; // Enable Footstep Sound Effect
        }
        
    }

    public void Interact()
    {
        // Reset Momentum
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        animator.SetTrigger("Interact");
        isInteracting = true;
        StartCoroutine(BacktoIdle());
    }

    IEnumerator BacktoIdle()
    {
        yield return new WaitForSeconds(1f);
        animator.ResetTrigger("Interact");
        isInteracting = false;
    }

    public void SetInteracting(bool ss)
    {
        isInteracting = ss;
    }

    public void SetRotationAngle(float angle)
    {
        rotationAngle = angle;
    }

    public float GetRotationAngle()
    {
        return rotationAngle;
    }
}
