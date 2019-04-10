using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    static float timer = 90.0f;
    public Text text_box;

	// Use this for initialization
	void Start () {
        timer = 90.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        text_box.text = timer.ToString("0.00");
        if (timer < 0.00)
        {
            SceneManager.LoadScene("DrawScene");
        }
	}
}
