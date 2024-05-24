using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class : 플레이어가 물줄기에 맞았는지 여부만 담당
/// </summary>
public class PlayerStreamDectector : MonoBehaviourPun
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
            photonView.RPC("CollisionStream", RpcTarget.MasterClient); // 권새롬추가 --> 마스터 클라이언트가 충돌함수를 호출함
        }
    }

    [PunRPC]
    public void CollisionStream()
    {
        if (playerMediator.playerState.ownState == PlayerStateMachine.State.Trapped) { return; }
        // Debug.Log("플레이어가 물줄기에 맞음");
        playerMediator.playerState.ChangeState(PlayerStateMachine.State.Trapped);
    }
}
