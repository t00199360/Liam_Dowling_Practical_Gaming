using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    

	public void PlayGame()
    {
        SceneManager.LoadScene("Test-Scene");
        
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
