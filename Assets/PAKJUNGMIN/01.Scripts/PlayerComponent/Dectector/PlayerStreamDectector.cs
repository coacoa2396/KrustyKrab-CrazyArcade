using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class : 플레이어가 물줄기에 맞았는지 여부만 담당
/// </summary>
public class PlayerStreamDectector : MonoBehaviour
{
    PlayerMediator playerMediator;

    private void Awake()
    {
        playerMediator = GetComponent<PlayerMediator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Stream>())
        {
            if(playerMediator.playerState.ownState == PlayerStateMachine.State.Trapped) { return; }
            Debug.Log("플레이어가 물줄기에 맞음");
            playerMediator.playerState.ChangeState(PlayerStateMachine.State.Trapped);
        }
    }
}
