using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    PlayerMediator playerMediator;

    private void Awake()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Drift>())
        {
            Debug.Log("플레이어가 물줄기에 맞음");
            playerMediator.playerState.ChangeState(PlayerStateMachine.State.Trapped);
        }
    }
}
