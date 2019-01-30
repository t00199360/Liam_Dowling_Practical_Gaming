﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    Vector3 direction, velocity, acceleration, worldGravity;
    float PlayerAmplitude = 0.1f;
    float PeriodOfMove = 1;
    bool isAirborne = false;
    bool touchingGround = true;

    float movementSpeed = 8, jumpForce = 15;

    float timeForMove;



    internal void setActive(bool v)
    {
        isActive = v;
    }

    bool isActive = false;

    enum Movement {walk, jump, fall};


    // Use this for initialization
    void Start ()
    {
        velocity = new Vector3(0, 7, 0);
        acceleration = new Vector3(0, -9, 0);
        worldGravity = new Vector3(0, -9.8f, 0);

        Movement movementMode;

        movementMode = Movement.walk;
	}
	
	// Update is called once per frame
	void Update ()
    {
		worldGravity = new Vector3(0,-12f,0);

        transform.position +=  movementSpeed * direction * Time.deltaTime;

        shouldMove();
	}

    /// <summary>
    /// Upon key press of [A] the selected character will move left
    /// </summary>
     
    private void shouldMove()
    {
        if (shouldMoveLeft())
        {
            moveLeft();
        }

        if (shouldMoveRight())
        {
            moveRight();
        }

        if (shouldJump())
        {
            jump();
        }

        if (isAirborne)
        {
            velocity += worldGravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;

            Vector3 dwn = Vector3.down;
            Debug.DrawRay(transform.position, dwn * 0.70f, Color.white, 1);
            RaycastHit info;
            if (Physics.Raycast(transform.position, dwn * 0.70f, out info, 1))
            {
                touchingGround = true;
                transform.position = info.point + 1f * Vector3.up;
            }
            else
                touchingGround = false;
        }
        if(touchingGround && isAirborne)
        {
            velocity = Vector3.zero;
            isAirborne = false;
        }
        stop(); 
    }       //end of should move

  
    private void stop()
    {
        direction = Vector3.zero;
    }
    private Boolean canJump()
    {
        return !isAirborne;
    }

    private void jump()
    {
        if (canJump())
        {
            isAirborne = true;
            velocity += Vector3.up * jumpForce;
        }
    }

    
    

    /// <summary>
    /// Upon key press of [A] + [A] in rapid succession (within 1 second) the character will sprint left at an increased speed
    /// </summary>
    private void DashLeft()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [D] + [D] in rapid succession (within 1 second), the character will sprint right at an increased speed
    /// </summary>
    private void DashRight()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [SPACEBAR], the character will execute a jump
    /// </summary>
    private void JumpCharacter()
    {
        throw new System.NotImplementedException();
    }

    private bool shouldMoveLeft()
    {                                           //determines whether or not the player should move left or not
        return Input.GetKey("a");
    }

    private void moveLeft()
    {
        direction = -transform.right;
    }

    private bool shouldMoveRight()
    {                                           //determines whether or not the player should move right or not
        return Input.GetKey("d");
    }

    /// <summary>
    /// Upon key press of [D] the selected character will move right
    /// </summary>
    private void moveRight()
    {
        direction = transform.right;
    }

    private bool shouldJump()
    {                                           //determines whether or not the player should be able to jump
        return Input.GetKey("space");
    }

    private bool shouldBlock()
    {
        return Input.GetKey("c");                //i will need a dedicated block button now instead of walking away from the attacker
    }

    private bool shouldDashLeft()
    {                                           //determines whether the player should dash left
        return Input.GetKey("a");               //needs a timer to see if the player should dash 
    }

    private bool shouldDashRight()
    {                                           //determines whether or not the player should dash right
        return Input.GetKey("d");                //needs a timer to see if the player should dash 
    }
}
