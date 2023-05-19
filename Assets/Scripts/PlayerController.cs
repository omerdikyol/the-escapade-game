using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{

    //! FIRST PERSON TESTING
    public bool isThirdPerson = true;

    Vector3 velocity;
    //! FIRST PERSON TESTING

    // Movement
    [SerializeField] private float _speed = 1;
    //[SerializeField] private float _jumpForce = 200;

    // Animation
    private Animator animator;
    public Vector3 moveDirection;
    private Rigidbody rb;
    public bool isInteracting;
    private AudioSource walkingAudio;

    private float audioPitch;

    // Rotation
    public float rotationAngle = 120f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isInteracting = false;
        walkingAudio = GetComponent<AudioSource>();
        audioPitch = walkingAudio.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThirdPerson)
        {
            ThirdPersonMovement();
        }
        else
        {
            FirstPersonMovement();
        }
    }

    private void ThirdPersonMovement()
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
    }

    private void FirstPersonMovement()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float baseSpeed = 4f;
        float gravity = -9.81f;
        float jumpHeight = 2f;
        float sprintSpeed = 4f;
        float speedBoost = 1f;

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire3"))
        {
            speedBoost = sprintSpeed;
            walkingAudio.pitch = audioPitch + 0.16f; // Make the sound effect faster
        }
        else
        {
            speedBoost = 1f;
            walkingAudio.pitch = audioPitch;
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Enable Footstep Sound Effect when moving
        if ((x != 0 || z != 0) && controller.isGrounded)
        {

            walkingAudio.enabled = true;
        }
        else
        {
            walkingAudio.enabled = false;
        }
    }
    public void Interact()
    {
        // Reset Momentum
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        animator.SetTrigger("Interact");
        animator.SetFloat("Speed", 0);
        walkingAudio.enabled = false; // Disable Footstep Sound Effect

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
