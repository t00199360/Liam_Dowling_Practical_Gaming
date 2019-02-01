using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{

    public float moveSpeed = 10f;
    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private float verticalJumpvel = 0;
    

    private Vector3 moveDirection = Vector3.zero;

 
    // Use this for initialization
    void Start()
    {
        print("Hey I'm a cube");

        onGround = false;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        print(jumpPressure);
        if (onGround)
        {   //holding jump button
            print("On Ground");
            shouldMove();
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
                print(jumpPressure);
                Debug.Log(jumpPressure);
            }
            //not holding jump button
            else
            {
                //jump
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    verticalJumpvel = jumpPressure;
                    jumpPressure = 0f;
                    onGround = false;
                }
            }
        }
        else
        {
            verticalJumpvel -= 9.8f * Time.deltaTime;
            transform.position += verticalJumpvel * Vector3.up*Time.deltaTime;

            onGround = checkOnGround();
        }
    }

    private bool checkOnGround()
    {
        Ray feet = new Ray(transform.position, Vector3.down);
        RaycastHit info;
        if (Physics.Raycast(feet,out info,(float)0.5))
            return  info.collider.gameObject.tag == "ground";

        return false;
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

        
    }       //end of should move


    /// <summary>
    /// Upon key press of [A] the selected character will move left
    /// </summary>

    private bool shouldMoveLeft()
    {                                           //determines whether or not the player should move left or not
        return Input.GetKey("a");
    }

    private void moveLeft()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
    }
    /// <summary>
    /// Upon key press of [D] the selected character will move right
    /// </summary>
    private bool shouldMoveRight()
    {                                           //determines whether or not the player should move right or not
        return Input.GetKey("d");
    }
    private void moveRight()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
    }


    private bool shouldBlock()
    {
        return Input.GetKey("c");                //i will need a dedicated block button now instead of walking away from the attacker
    }


}