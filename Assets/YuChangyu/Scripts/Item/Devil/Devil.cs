using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 Devil
/// 지속시간동안 방향입력이 반대로 되거나 물풍선을 마구 놓는 상태로 변한다
/// </summary>
public class Devil : Item
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            if (WaterProof <= 0)
            {
                //권새롬 추가 --> 아이템 삭제는 마스터 클라이언트만. (룸오브젝트이기 때문)
                if (PhotonNetwork.IsMasterClient)
                    PhotonNetwork.Destroy(gameObject);
                return;
            }
            WaterProof--;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = Player = collision.gameObject.GetComponent<PlayerMediator>();

        Execute();

        if (collision.gameObject.GetComponent<PhotonView>().IsMine)
            Manager.Sound.PlaySFX("EatItem");

        // Player에서 PlayerState를 받아오고
        // Random.Range(0,2)를 해서
        // 0이면 반대입력상태
        // 1이면 물풍선 마구 놓는 상태
        int ownerId = Player.GetComponent<PhotonView>().OwnerActorNr;
        if (photonView.IsMine)
            photonView.RPC("AddInven", RpcTarget.All, "Devil", ownerId);
        gameObject.SetActive(false);
    }

    public override void Execute()
    {
        Player.playerState.ChangeState(PlayerStateMachine.State.Devil);
    }
}
