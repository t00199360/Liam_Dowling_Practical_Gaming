using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class ACHIEVEMENTSYSTEM : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        
        PointOfInterest.OnPointOfInterestEntered += 
            PointOfInterest_OnPointOfInterestEntered;

        
        
    }

    private void OnDestroy()            //deregisters events
    {
        PointOfInterest.OnPointOfInterestEntered -=
            PointOfInterest_OnPointOfInterestEntered;
    }


    private void PointOfInterest_OnPointOfInterestEntered(PointOfInterest poi)
    {
        string achievementKey = "achievement-" + poi.PoiName;

        if (PlayerPrefs.GetInt(achievementKey) == 1)
            return;

        PlayerPrefs.SetInt(achievementKey, 1);
        Debug.Log("Unlocked " + poi.PoiName);

    }
    
}