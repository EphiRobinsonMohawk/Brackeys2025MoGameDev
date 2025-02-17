using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float gravity = -9.81f;
    public float crouchWalkSpeed;
    bool crouching = false;


    public Vector3 offset;

    public Transform player;

    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air,
        crouching
    }

    Vector3 velocity;
    bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       // reset velocity when grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        StateHandler();
        BasicMovement();
        


    }

    private void StateHandler()
    {
        //crouching
        if (Input.GetKeyDown(crouchKey))
        {
            crouching = true;
        }
        if (Input.GetKeyUp(crouchKey))
        {
            crouching = false;
        }
        if (crouching == true)
        {
            state = MovementState.crouching;
            moveSpeed = crouchWalkSpeed;
            
        }
            
        
            
        
        
        //sprinting
        if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //ground
        else if (isGrounded && crouching == false)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        else
        {
            state = MovementState.air;
        }

    }

    private void BasicMovement()
    {
        // reset velocity when grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //basic movement and gravity 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


}
