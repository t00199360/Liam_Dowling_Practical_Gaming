using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    enum JumpState { OnGround, Charging, GoingUp, Falling }

    JumpState iamCurrently = JumpState.OnGround;
    float _jumpPressure = 0;
    float MAX_PRESSURE = 1;
    private float MIN_JUMP_PRESSURE = 0.1F;
    private float gravity = 0.85f;

    public float jumpPressure { get { return _jumpPressure; } private set { _jumpPressure = Mathf.Clamp(value, 0, MAX_PRESSURE); } }

    public float moveSpeed = 10f;
    private bool onGround;



    private float verticalJumpvel = 0;
    private Boolean isKeysEnabled = true;
    public float ColliderTimeout = 0.8f;
    public float jumpTimer = 2f;

    //  Quaternion targetRight = new Quaternion(0, 45, 0, 1);
    //  Vector3 targetLeft = new Vector3(-100, 0, 0);

    public Collider[] attackHitBoxes;

    protected Animator animate;

    private float defaultHeightForCharacterOnGround = 0;

    // private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        animate = GetComponent<Animator>();

        onGround = false;
        jumpPressure = 0f;
       

        ////animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checkOnGround();
        Debug.DrawRay(transform.position, Vector3.down * 0.05f, Color.cyan);
        Debug.Log(jumpTimer + " I am the jump timer " + " Is Keys " + isKeysEnabled + " Is onGround? " + onGround);
        shouldMove();

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            animate.SetBool("IsRunning", false);
        }

        if (Input.GetKeyUp("1"))
        {
            animate.SetBool("IsPunching", false);
        }

        if (Input.GetKeyUp("2"))
        {
            animate.SetBool("IsKicking", false);
        }

        switch (iamCurrently)

        {

            case JumpState.OnGround:

                if (Input.GetKey(KeyCode.Space))
                {
                    iamCurrently = JumpState.Charging;
                    jumpPressure = 0;
                }



                break;

            case JumpState.Charging:

                if (Input.GetKey(KeyCode.Space))
                {
                    jumpPressure += Time.deltaTime;

                }

                else
                {
                    iamCurrently = JumpState.GoingUp;
                    if (jumpPressure < MIN_JUMP_PRESSURE) jumpPressure = MIN_JUMP_PRESSURE;
                    verticalJumpvel = getStartingJumpVerticalVelocityFor(jumpPressure);

                }

                break;

            case JumpState.GoingUp:

                verticalJumpvel -= gravity * Time.deltaTime;
                transform.position += verticalJumpvel * Vector3.up;
                if (verticalJumpvel < 0)
                    iamCurrently = JumpState.Falling;






                break;


            case JumpState.Falling:

                verticalJumpvel -= gravity * Time.deltaTime;
                transform.position += verticalJumpvel * Vector3.up;

                if (checkOnGround())
                {
                    iamCurrently = JumpState.OnGround;
                    transform.position = new Vector3(transform.position.x, defaultHeightForCharacterOnGround, transform.position.z);
                }

                break;

        }

        
    }

    private float getStartingJumpVerticalVelocityFor(float jumpPressure)
    {
        return jumpPressure * 0.5F;
    }


    private bool checkOnGround()
    {
        Ray feet = new Ray(transform.position, Vector3.down);
        RaycastHit info;
        if (Physics.Raycast(feet, out info, (float)0.5))
        {
            if(info.collider.gameObject.tag=="ground")
            {
                onGround = true;
            }
            return info.collider.gameObject.tag == "ground";
        }
        return false;
    }

    public void jumpTimeWait()
    {
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0)
        {
            Debug.Log("The jump wait has expired");
            isKeysEnabled = true;
            jumpTimer = 2f;
        }
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