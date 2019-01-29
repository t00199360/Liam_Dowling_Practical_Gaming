using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class characterMovementScript : MonoBehaviour
{

    //Define the direction the worm is facing and the falling speed (gravity)
    Vector3 direction, velocity, acceleration, wormGravity;
    float AmplitudeForWormSlither = 0.1f;
    float PeriodOfSlither = 1;
    playerControls myController;
  

    int imOnTeam;
    int teamMember;

    Boolean isAirbourne = false;
    Boolean touchingGround = true;



    //Define walking speed variable and turning speed variable
    float walkingSpeed = 3, turningSpeed = 60, jumpForce = 10;
    private float timeForSlither;

    internal void setActive(bool v)
    {
        isActive = v;
       

    }

    bool isActive = false;


    enum Movement { slither, jump, fall };

  






    // Use this for initialization
    void Awake()
    {
        // gameObject.SetActive(false);

        myController = FindObjectOfType<playerControls>();

        velocity = new Vector3(0, 7, 0);
        acceleration = new Vector3(0, -9, 0);
        wormGravity = new Vector3(0, -9.8f, 0);

        Movement movementMode;

        movementMode = Movement.slither;

       
        /* relocated from health script
         FloatingDisplay ourHealthDisplay;
         */

    }

    //Creates a link between teamInventory and ProjectileSpawner
   

    internal bool isWormActive()
    {
        return isActive;
    }

    // Update is called once per frame
    void Update()
    {



        if (isActive)
        {

            //shouldGoForward() method defines the key press (w)
            if (shouldGoForward())
            {
                //Applies actual movement equation forward
                goForward();
                wormWalk();
            }

            //shouldGoBack() method defines the key press (s)
            if (shouldGoBackwards())
            {
                //Applies actual movement equation backward
                goBackwards();
            }

            //shouldRotateLeft() method defines the key press (a)
            if (shouldRotateLeft())
            {
                //Applies actual movement equation left
                rotateLeft();
            }

            //shouldRotateRight() method defines the key press (d)
            if (shouldRotateRight())
            {
                //Applies actual movement equation right
                rotateRight();
            }

            //shouldStrafeLeft() method defines the key press (q)
            if (shouldStrafeLeft())
            {
                strafeLeft();
            }
            //shouldStrafeRight() method defines the key press (e)
            if (shouldStrafeRight())
            {
                strafeRight();
            }
            if (shouldJump())
            {
                jump();
            }

            //The movement equation, updates position of the worm on key press
            transform.position += walkingSpeed * direction * Time.deltaTime;

            //Decision taken not to disable lateral movement during jump for the retro feel. - Ian
            if (isAirbourne)
            {
                velocity += wormGravity * Time.deltaTime;
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
            if (touchingGround && isAirbourne)
            {
                velocity = Vector3.zero;
                isAirbourne = false;

            }
            //This allows the worm to stop when the key is released
            stop();
        }//End isActive

    }

    internal void introduction(playerControls playerControl)
    {
        myController = playerControl;
    }

    internal void yourDead()
    {
     

        Destroy(gameObject);

    }


    private bool shouldStrafeRight()
    {
        return Input.GetKey("e");
    }

    private void strafeRight()
    {
        direction = transform.right;
    }

    private bool shouldStrafeLeft()
    {
        return Input.GetKey("q");
    }

    private void strafeLeft()
    {
        direction = -transform.right;
    }

    private void wormMovement()
    {
        //shouldGoForward() method defines the key press (w)
        if (shouldGoForward())
        {
            //Applies actual movement equation forward
            goForward();
            wormWalk();
        }

        //shouldGoBack() method defines the key press (s)
        if (shouldGoBackwards())
        {
            //Applies actual movement equation backward
            goBackwards();
        }

        //shouldRotateLeft() method defines the key press (a)
        if (shouldRotateLeft())
        {
            //Applies actual movement equation left
            rotateLeft();
        }

        //shouldRotateRight() method defines the key press (d)
        if (shouldRotateRight())
        {
            //Applies actual movement equation right
            rotateRight();
        }

        if (shouldJump())
        {
            jump();
        }


        //The movement equation, updates position of the worm on key press
        transform.position += walkingSpeed * direction * Time.deltaTime;

        //This allows the worm to stop when the key is released
        direction = Vector3.zero;
    }
    private void wormWalk()
    {
        timeForSlither += Time.deltaTime;
        // print(( timeForSlither) * (2 * Mathf.PI) / PeriodOfSlither);
        foreach (Transform child in transform)
            child.localScale = new Vector3(1 + AmplitudeForWormSlither * Mathf.Sin(((2 * Mathf.PI) * timeForSlither) / PeriodOfSlither), 1, 1);
        ;
    }

    private Boolean canJump()
    {
        return !isAirbourne;
    }
    private void jump()
    {

        if (canJump())
        {
            //Up ward code stuff
            isAirbourne = true;
            touchingGround = false;
            velocity += Vector3.up * jumpForce;
        }

    }

    private void stop()
    {
        direction = Vector3.zero;
    }

    private bool shouldJump()
    {
        return Input.GetKeyDown("z");
    }

    private bool shouldRotateLeft()
    {
        return Input.GetKey("a");
    }

    private void rotateLeft()
    {
        transform.Rotate(transform.up, -turningSpeed * Time.deltaTime);
    }

    private bool shouldRotateRight()
    {
        return Input.GetKey("d");
    }
    private void rotateRight()
    {
        transform.Rotate(transform.up, +turningSpeed * Time.deltaTime);
    }

    private void goBackwards()
    {
        direction = -transform.forward;
    }

    private bool shouldGoBackwards()
    {
        return Input.GetKey("s");
    }

    void goForward()
    {

        direction = transform.forward;


    }
    private bool shouldGoForward()
    {
        return Input.GetKey("w");
    }
}
