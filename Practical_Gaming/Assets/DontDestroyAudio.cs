using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
