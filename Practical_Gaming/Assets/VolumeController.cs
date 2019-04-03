using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

    public static float volumePass = 0;
    public Slider Volume;
    public AudioSource myMusic;
	// Update is called once per frame
	void Update ()
    {
        myMusic.volume = Volume.value;
        volumePass = myMusic.volume;
	}

    public static float passVolume()
    {
        return volumePass;
    }
}
