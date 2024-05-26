using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BubbleCollider : MonoBehaviour
{
    [SerializeField] PlayerStateMachine playerState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (playerState.ownState != PlayerStateMachine.State.Trapped) { return; }

            playerState.ChangeState(PlayerStateMachine.State.Die);

        }
    }


}
