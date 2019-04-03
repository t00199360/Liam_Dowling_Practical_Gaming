using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMatch : MonoBehaviour {

    public float Volume;
    
    public AudioSource myMusic;
    // Update is called once per frame
    void Update()
    {
        Volume = VolumeController.passVolume();
        myMusic.volume = Volume;
    }
}
