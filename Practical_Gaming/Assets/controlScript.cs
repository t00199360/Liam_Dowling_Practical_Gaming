using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    private int PlayerSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Upon key press of [A] the selected character will move left
    /// </summary>
    private void MoveLeft()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [D] the selected character will move right
    /// </summary>
    private void MoveRight()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [A] + [A] in rapid succession (within 1 second) the character will sprint left at an increased speed
    /// </summary>
    private void DashLeft()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [D] + [D] in rapid succession (within 1 second), the character will sprint right at an increased speed
    /// </summary>
    private void DashRight()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [SPACEBAR], the character will execute a jump
    /// </summary>
    private void JumpCharacter()
    {
        throw new System.NotImplementedException();
    }
}
