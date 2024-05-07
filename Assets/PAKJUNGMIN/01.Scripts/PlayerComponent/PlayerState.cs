using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum PlayerStates
    {
        Alive,
        Trapped,
        Die,
    }

    public PlayerStates ownState;

    void ChangeState()
    {

    }
    void Alive() { }
    void Trapped() { }
    void Die() { }
    
}
