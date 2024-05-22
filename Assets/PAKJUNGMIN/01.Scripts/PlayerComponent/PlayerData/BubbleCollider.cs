using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BubbleCollider : MonoBehaviour
{
    [SerializeField] PlayerStateMachine playerState;

    int otherPlayerLayer;

    private void Awake()
    {
        otherPlayerLayer = LayerMask.NameToLayer("Player");
        Debug.Log($"otherPlayerLayer : {otherPlayerLayer}");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"123123123123123123123123123123123123123");
        if ((gameObject.layer | otherPlayerLayer) != 0)
        {
            Debug.Log($"123433443");
            playerState.ChangeState(PlayerStateMachine.State.Die);
        }
    }


}
