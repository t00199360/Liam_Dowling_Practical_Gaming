using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firepoint;
    public GameObject bulletPrefab;
    public Transform firepoint2;
    public GameObject bulletPrefab2;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            Shoot2();
        }
	}

    void Shoot()
    {
        Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
        //  shooting logic
    }

    void Shoot2()
    {
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        //  shooting logic
    }
}
