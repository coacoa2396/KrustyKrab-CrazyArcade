using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForwardGuide : MonoBehaviour
{
   public enum ForwardState
    {
        up,
        down,
        left,
        right
    }
    ForwardState forwardState;

    public ForwardState Forward { get { return forwardState; } }

    public void ChangeForward(ForwardState state)
    {
        forwardState = state;
        switch (forwardState)
        {
            case ForwardState.up:
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 0.5f, 0);
                break;
            case ForwardState.down:
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y - 0.5f, 0);
                break;
            case ForwardState.left:
                transform.position = new Vector3(transform.parent.position.x + 0.5f, transform.parent.position.y, 0);
                break;
            case ForwardState.right:
                transform.position = new Vector3(transform.parent.position.x - 0.5f, transform.parent.position.y, 0);
                break;
        }
    }
}
