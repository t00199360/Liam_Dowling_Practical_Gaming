using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Control : MonoBehaviour
{

    public float moveSpeed = 10f;
    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private float verticalJumpvel = 0;
    Quaternion targetRight = new Quaternion(0, 45, 0, 1);
    Vector3 targetLeft = new Vector3(-100, 0, 0);


    Animator animate;
    private Vector3 moveDirection = Vector3.zero;


    // Use this for initialization
    void Start()
    {
        print("Hey I'm player 2");
        
        onGround = false;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 7f;

        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animate.SetBool("IsRunning", false);
        }

        if(Input.GetKeyUp(KeyCode.Keypad1))
        {
            animate.SetBool("IsPunching", false);
        }

        print(jumpPressure);
        if (onGround)
        {   //holding jump button
            print("On Ground");
            shouldMove();
            if (Input.GetKey(KeyCode.Keypad0))
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
            transform.position += verticalJumpvel * Vector3.up * Time.deltaTime;

            onGround = checkOnGround();
        }
    }

    private bool checkOnGround()
    {
        Ray feet = new Ray(transform.position, Vector3.down);
        RaycastHit info;
        if (Physics.Raycast(feet, out info, (float)0.5))
            return info.collider.gameObject.tag == "ground";

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
        if (shouldPunch())
        {
            punch();
        }



    }       //end of should move


    /// <summary>
    /// Upon key press of [A] the selected character will move left
    /// </summary>

    private bool shouldMoveLeft()
    {                                           //determines whether or not the player should move left or not
        return Input.GetKey(KeyCode.LeftArrow);
    }

    private void moveLeft()
    {
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("HorizontalP2") * Time.deltaTime * -1);
        transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        animate.SetBool("IsRunning", true);
    }
    /// <summary>
    /// Upon key press of [D] the selected character will move right
    /// </summary>
    private bool shouldMoveRight()
    {                                           //determines whether or not the player should move right or not
        return Input.GetKey(KeyCode.RightArrow);
    }
    private void moveRight()
    {
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("HorizontalP2") * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        animate.SetBool("IsRunning", true);
    }


    private bool shouldBlock()
    {
        return Input.GetKey(KeyCode.DownArrow);                //i will need a dedicated block button now instead of walking away from the attacker
    }

    private bool shouldPunch()
    {
        return Input.GetKey(KeyCode.Keypad1);
    }

    private void punch()
    {
        animate.SetBool("IsPunching", true);
    }

}