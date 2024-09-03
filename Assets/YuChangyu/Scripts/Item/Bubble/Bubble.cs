using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : 물풍선 
/// 플레이어가 한번에 놓을 수 있는 물풍선의 갯수가 1 증가한다
/// </summary>
public class Bubble : Item
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            if (WaterProof <= 0)
            {
                //아이템 삭제는 마스터 클라이언트만. (룸오브젝트이기 때문)
                if (PhotonNetwork.IsMasterClient)
                    PhotonNetwork.Destroy(gameObject);
                return;
            }
            WaterProof--;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        Execute();

        if (collision.gameObject.GetComponent<PhotonView>().IsMine)
            Manager.Sound.PlaySFX("EatItem");

        int ownerId = Player.GetComponent<PhotonView>().OwnerActorNr;
        if (photonView.IsMine)
            photonView.RPC("AddInven", RpcTarget.All, "Bubble", ownerId);
        gameObject.SetActive(false);
    }

    public override void Execute()
    {
        Player.playerStats.OwnBomb++;
    }
}
