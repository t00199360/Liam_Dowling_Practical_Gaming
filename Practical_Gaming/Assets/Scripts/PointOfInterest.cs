using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{

    //public static event Action<PointOfInterest>OnPointOfInterestEntered;

    [SerializeField]
    private string poiName;
    
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        Notify(poiName, NotificationType.AchievementUnlocked);
    }
}
