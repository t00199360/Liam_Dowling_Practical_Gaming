using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firepoint2;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot2();
        }
    }

    void Shoot2()
    {
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        //  shooting logic
    }
}
