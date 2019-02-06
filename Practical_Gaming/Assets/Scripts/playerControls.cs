using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

    float chainTimer = 0.5f;
    float gameTimer = 90f;
    
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


    }

    void chainTimerMethod()
    {
        chainTimer -= Time.deltaTime;

        if(chainTimer<=0)                       //this timer is used to determine wether or not the player has executed a combo move
        {
            Debug.Log("Chain Timer has expired");
        }
    }

    void gameTimerMethod()
    {
        gameTimer -= Time.deltaTime;            //this timer is used to determine wether or not the round has ran out of time or not

        if(gameTimer<=0)
        {
            Debug.Log("Game Timer has expired! The round is over");
        }
    }
    


}
