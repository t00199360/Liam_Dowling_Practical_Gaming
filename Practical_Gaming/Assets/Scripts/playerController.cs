using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("horizontal");
        float moveUp = Input.GetAxis("Up");

        Vector3 movement = new Vector3(moveHorizontal, moveUp, 0.0f);
        rb.AddForce(movement);
    }
}
