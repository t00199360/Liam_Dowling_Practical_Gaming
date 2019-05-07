using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class ACHIEVEMENTSYSTEM : Observer
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();

        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);
        }

        //PointOfInterest.OnPointOfInterestEntered += 
        //    PointOfInterest_OnPointOfInterestEntered;

    }

    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.AchievementUnlocked)
        {
            string achievementKey = "achievement-" + value;

            if (PlayerPrefs.GetInt(achievementKey) == 1)
                return;

            PlayerPrefs.SetInt(achievementKey, 1);
            Debug.Log("Unlocked-" + value);
        }
    }
}

public enum NotificationType
{
    AchievementUnlocked
}


    //private void OnDestroy()            //deregisters events
    //{
    //    PointOfInterest.OnPointOfInterestEntered -=
    //        PointOfInterest_OnPointOfInterestEntered;
    //}


    //private void PointOfInterest_OnPointOfInterestEntered(PointOfInterest poi)
    //{
    //    string achievementKey = "achievement-" + poi.PoiName;

    //    if (PlayerPrefs.GetInt(achievementKey) == 1)
    //        return;

    //    PlayerPrefs.SetInt(achievementKey, 1);
    //    Debug.Log("Unlocked " + poi.PoiName);

    //}