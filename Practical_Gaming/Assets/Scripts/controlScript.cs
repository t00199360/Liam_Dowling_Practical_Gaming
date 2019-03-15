using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    //public string fighterName;
    //public static float MaxHealth = 100f;
    //public float health = MaxHealth;
    //public controlScript opponent;
    public float moveSpeed = 10f;
    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private float verticalJumpvel = 0;
   // Quaternion targetRight = new Quaternion(0, 45, 0, 1);
   // Vector3 targetLeft = new Vector3(-100, 0, 0);

    public Collider[] attackHitBoxes;                   //help reference: https://www.youtube.com/watch?v=mvVM1RB4HXk


    protected Animator animate;
   // private Vector3 moveDirection = Vector3.zero;


    // Use this for initialization
    void Start()
    {
        animate = GetComponent<Animator>();
        print("Hey I'm player 2");

        onGround = false;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 7f;

        ////animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        shouldMove();
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            animate.SetBool("IsRunning", false);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            animate.SetBool("IsPunching", false);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            animate.SetBool("IsKicking", false);
        }
        
        print(jumpPressure);
        if (onGround)
        {   //holding jump button
            print("On Ground");
            //shouldMove();
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
            // verticalJumpvel -= 9.8f * Time.deltaTime;
            // transform.position += verticalJumpvel * Vector3.up * Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * verticalJumpvel, ForceMode.Impulse);

            onGround = checkOnGround();
        }
    }


    private bool checkOnGround()
    {
        Ray feet = new Ray(transform.position, Vector3.down);
        RaycastHit info;
        if (Physics.Raycast(feet, out info, (float)0.5))
            return info.collider.gameObject.tag == "ground";
        Debug.Log("I am here");
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

        if (shouldKick())
        {
            kick();
        }


    }       //end of should move


    /// <summary>
    /// Upon key press of [A] the selected character will move left
    /// </summary>

    private bool shouldKick()
    {
        return Input.GetKey(KeyCode.Alpha2);
    }

    private void kick()
    {
        LaunchAttack(attackHitBoxes[1]);
        animate.SetBool("IsKicking", true);
    }

    private bool shouldMoveLeft()
    {                                           //determines whether or not the player should move left or not
        return Input.GetKey("a");
    }

    private void moveLeft()
    {
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * -1);
        transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        animate.SetBool("IsRunning", true);
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
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        animate.SetBool("IsRunning", true);
    }


    private bool shouldBlock()
    {
        return Input.GetKey("c");                //i will need a dedicated block button now instead of walking away from the attacker
    }

    private bool shouldPunch()
    {
        return Input.GetKey(KeyCode.Alpha1);
    }

    private void punch()
    {
        LaunchAttack(attackHitBoxes[0]);
        animate.SetBool("IsPunching", true);
      //  Collision punch = new Collision();
       // OnCollisionEnter(punch);
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.layer);
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.layer);
    //    //if (collision.gameObject.tag == "Player2")
    //    //{
    //    //    Debug.Log("A punch was executed");
    //    //}
    //}

    private void LaunchAttack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        //foreach (Collider c in cols)
        //    Debug.Log(c.name);

        foreach (Collider c in cols)
        {
            if (c.transform.transform == transform)
                continue;

            float damage = 0;
            switch (c.name)
            {
                case "char_robotGuard_Head":
                    damage = 25;
                    break;

                case "char_robotGuard_Hips":
                    damage = 10;
                    break;

                case "char_robotGuard_LeftUpLeg":
                    damage = 5;
                    break;

                case "char_robotGuard_RightUpLeg":
                    damage = 5;
                    break;

                case "char_robotGuard_LeftShoulder":
                    damage = 5;
                    break;

                case "char_robotGuard_RightShoulder":
                    damage = 5;
                    break;

                default:
                    Debug.Log("Unable to identify body part, make sure the name matches the switch case");
                    break;
            }

            c.SendMessageUpwards("TakeDamage", damage);
        }
    }
}