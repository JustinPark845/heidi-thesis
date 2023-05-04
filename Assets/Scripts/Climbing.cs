using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;

    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask whatIsWall;

    [Header("Climbing")]
    public float climbSpeed;
    private float maxClimbTime = Mathf.Infinity;
    private float climbTimer;

    private bool climbing;

    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;

    [Header("Slow Movement")]
    [Tooltip("Movement to slow down when crouched.")]
    public FirstPersonMovement movement;
    [Tooltip("Movement speed when climbing.")]
    public float movementSpeed = 2;

    [Header("Visualize Ray")]
    public bool toggle = false;

    private void Awake()
    {
        movement = GetComponentInParent<FirstPersonMovement>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        WallCheck();
        StateMachine();

        if (climbing)
        {
            SetSpeedOverrideActive(true);
            ClimbingMovement();
        } else
        {
            SetSpeedOverrideActive(false);
        }
    }

    private void StateMachine()
    {
        // State 1 - Climbing
        if (wallFront && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && wallLookAngle < maxWallLookAngle)
        {
            if (!climbing && climbTimer > 0) StartClimbing();
            // timer1
            if (climbTimer > 0) climbTimer -= Time.deltaTime;
            if (climbTimer < 0) StopClimbing();
        }

        // State 2 - Exiting
        //else if (exitingWall)
        //{
        //    if (climbing) StopClimbing();

        //    if (exitWallTimer > 0) exitWallTimer -= Time.deltaTime;
        //    if (exitWallTimer < 0) exitingWall = false;
        //}

        // State 3 - None
        else
        {
            if (climbing) StopClimbing();
        }
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position + new Vector3(0,sphereCastRadius,0), sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        if (!groundCheck || groundCheck.isGrounded)
        {
            climbTimer = maxClimbTime;
        }
    }

    private void StartClimbing()
    {
        climbing = true;

        /// idea - camera fov change
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);

        /// idea - sound effect
    }

    private void StopClimbing()
    {
        climbing = false;

        /// idea - particle effect
        /// idea - sound effect
    }

    void SetSpeedOverrideActive(bool state)
    {
        // Stop if there is no movement component.
        if (!movement)
        {
            return;
        }

        // Update SpeedOverride.
        if (state)
        {
            // Try to add the SpeedOverride to the movement component.
            if (!movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Add(SpeedOverride);
            }
        }
        else
        {
            // Try to remove the SpeedOverride from the movement component.
            if (movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Remove(SpeedOverride);
            }
        }
    }
    float SpeedOverride() => movementSpeed;

    private void OnDrawGizmosSelected()
    {
        if (toggle)
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(transform.position + new Vector3(0, sphereCastRadius, 0), transform.position + orientation.forward * detectionLength);
            Gizmos.DrawWireSphere(transform.position + new Vector3(0, sphereCastRadius, 0) + orientation.forward * detectionLength, sphereCastRadius);
        }
    }
}
