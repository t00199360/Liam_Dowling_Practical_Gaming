using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody rb;
    public float bulletTime = 3f;
    
	// Use this for initialization
	void Start () {
        rb.velocity = transform.forward * speed;	
	}

    private void Update()
    {
        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        Vector3 euler = faceCamera.eulerAngles;
        euler.y = 0f;
        faceCamera.eulerAngles = euler;
        transform.rotation = faceCamera;
        chainTimerMethod();
    }

    void chainTimerMethod()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime <= 0)                       //this timer is used to determine when the gameobject "bullet" should be destroyed
        {
            Destroy(gameObject);
            Debug.Log("projectile has expired");
        }
    }
}
