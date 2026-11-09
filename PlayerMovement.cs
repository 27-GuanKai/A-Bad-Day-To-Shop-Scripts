using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     
    //Movement
    public float moveSpeed;

    public float groundDrag;
    
    public float jumpforce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readytoJump;
    //KeyBinds
    public KeyCode jumpkey = KeyCode.Space;
    //Ground check
    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public LayerMask Escalator;
    bool OnEscalator;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    public AudioSource PlayerSource;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readytoJump = true;
        PlayerSource = PlayerSource.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        userinput();
        SpeedControl();
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        //Escalator
        OnEscalator = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Escalator);
        
    }
    private void userinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //when to jump
        if (Input.GetKeyDown(jumpkey) && readytoJump && grounded)
        {
            
            readytoJump = false;

            Jump();
            Invoke(nameof(resetJump), jumpCoolDown);
            
        }
    }
    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //On Ground
        if (grounded)
        {
            
            
            if (OnEscalator)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 20f, ForceMode.Force);
            }
            else if (!OnEscalator)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
          

        }
        //In Air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            
        }
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //velocity limiter
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
        
   }
    private void resetJump()
    {
        readytoJump = true;
    }
}
