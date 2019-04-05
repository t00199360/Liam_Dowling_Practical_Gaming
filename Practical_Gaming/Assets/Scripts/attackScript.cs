using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    /// <summary>
    /// Tells the system if the player is blocking
    /// </summary>
    private bool blocking;
    /// <summary>
    /// Tells the system if the player is successfully executing a counter attack
    /// </summary>
    private bool counter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Upon key press of [B], the character wll execute a quick punch at medium height
    /// </summary>
    private void LightPunch()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [N], the character wll execute a slower, heavy punch at medium height (breaks blocks)
    /// </summary>
    private void HeavyPunch()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [S] + [B] in rapid succession (within 1 second), the character will execute a low attack
    /// </summary>
    private void LowAttack()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [W] + [N] in rapid succession (within 1 second), the character will execute a heavy high attack
    /// </summary>
    private void HighAttack()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon key press of [M], the character will execute a "zone"/ranged attack that will traverse the battlefield.
    /// </summary>
    private void ZoneAttack()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Moving away from an attack will put the character into a "blocking stance" that will nullify a quick attack and break the assailants combo, and reduce damage from a heavy attack
    /// </summary>
    private void BlockAttack()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Upon blocking a quick attack, and executing a quick attack in rapid succession (half a second), the character will stun the assailant and execute a heavy attack
    /// </summary>
    private void CounterAttack()
    {
        throw new System.NotImplementedException();
    }
}


