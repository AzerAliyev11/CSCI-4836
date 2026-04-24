using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    private Rigidbody rb;
    private RaycastHit leftWallHit, rightWallHit;

    //movement variables
    private float hMovement, vMovement;
    private float moveSpeed = 5f;
    private float wallCheckDistance = 0.7f;
    private float wallJumpUpForce = 8f;
    private bool jumpAvailable = false; 
    private bool isWallRunning = false;

    private float wallJumpTimer;
    private float wallJumpDuration = 0.3f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetMovementInput();
        
        // Countdown the timer
        if (wallJumpTimer > 0) wallJumpTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && !jumpAvailable)
        {
            jumpAvailable = true;
        }
        CheckForWall();
        StateMachine();
        ApplyJump();
    }

    void FixedUpdate()
    {
        if(!isWallRunning)
        {
            rb.velocity = new Vector3(hMovement * moveSpeed, rb.velocity.y, vMovement * moveSpeed);
        }
    }

    private void CheckForWall()
    {
        Physics.Raycast(transform.position, -transform.right, out leftWallHit, wallCheckDistance);
        Physics.Raycast(transform.position, transform.right, out rightWallHit, wallCheckDistance);
    }

    private void GetMovementInput()
    {
        hMovement = Input.GetAxis("Horizontal");
        vMovement = Input.GetAxis("Vertical");
    }

    private void ApplyJump()
    {
        if(jumpAvailable)
        {
            if(IsGrounded())
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }
            else if(!IsGrounded() && isWallRunning)
            {
                StopWallRun();
                WallJump();
            }
        }
        jumpAvailable = false;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void StateMachine()
    {
        if ((leftWallHit.collider || rightWallHit.collider) && !IsGrounded() && wallJumpTimer <= 0)
        {
            StartWallRun();
        }
        else
        {
            StopWallRun();
        }
    }

    void StartWallRun()
    {
        isWallRunning = true;
        rb.useGravity = false;

        Vector3 wallNormal = leftWallHit.collider ? leftWallHit.normal : rightWallHit.normal;

        Vector3 currentVel = rb.velocity;
        Vector3 runDirection = currentVel - Vector3.Dot(currentVel, wallNormal) * wallNormal;
        
        rb.velocity = new Vector3(runDirection.x, 0, runDirection.z).normalized * moveSpeed * 2f;
        
        rb.AddForce(-wallNormal * 10f, ForceMode.Force);
    }

    void StopWallRun()
    {
        isWallRunning = false;
        rb.useGravity = true;
    }

    void WallJump()
    {
        // Set the timer to prevent immediate re-sticking
        wallJumpTimer = wallJumpDuration;

        Vector3 wallNormal = leftWallHit.collider ? leftWallHit.normal : rightWallHit.normal;
        
        // Increased the side force (wallNormal * 10f) so the push-away is more noticeable
        Vector3 jumpForce = transform.up * wallJumpUpForce + wallNormal * 10f;
        
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(jumpForce, ForceMode.Impulse);
    }
}
