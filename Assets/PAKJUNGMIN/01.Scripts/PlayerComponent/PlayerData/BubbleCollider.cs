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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Bubble Collider Layer {gameObject.layer}");
        Debug.Log($"otherPlayerLayer : {otherPlayerLayer}");
        Debug.Log($"PlayerLayer : {transform.parent.gameObject.layer}");
        if ((gameObject.layer & otherPlayerLayer) != 0)
        {
            Debug.Log("sss");
            playerState.ChangeState(PlayerStateMachine.State.Die);
        }
    }


}
