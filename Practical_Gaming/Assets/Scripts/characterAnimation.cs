using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimation : MonoBehaviour
{
    /// <summary>
    /// Tells the system if the character is crouched
    /// </summary>
    private bool crouched;
    /// <summary>
    /// Tells the system if the character is jumping
    /// </summary>
    private bool jumping;
    /// <summary>
    /// Tells the system if the character is punching
    /// </summary>
    private bool punching;
    /// <summary>
    /// Tells the system if the character is kicking
    /// </summary>
    private bool kicking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// There will need to be an idle animation for the characters.
    /// </summary>
    private void ReadyStance()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Jump animation will consist of the model bending its legs and transforming its position upwards, decelerating and then coming back down.
    /// </summary>
    private void JumpAnimation()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Punch animtion will consist of the character extending their arm with a clenched fist at medium height
    /// </summary>
    private void PunchAnimation()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Kick animation will depend on the character selected
    /// </summary>
    private void KickAnimation()
    {
        throw new System.NotImplementedException();
    }
}
