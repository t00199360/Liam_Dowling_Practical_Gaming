using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour
{
    public string punchname;
    public float damage;

    public controlScript owner;

    private void OnTriggerEnter(Collider other)
    {
        controlScript somebody = other.gameObject.GetComponent<controlScript>();

        if(somebody != null && somebody != owner)
        {
            Debug.Log("I hit " + somebody + " with " + punchname);
        }
    }
}
