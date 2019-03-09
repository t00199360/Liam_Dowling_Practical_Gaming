using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        rb.velocity = transform.forward * speed;	
	}
}
