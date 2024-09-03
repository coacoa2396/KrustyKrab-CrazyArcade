using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 지속시간 동안 모든 공격을 방어한다
/// </summary>
public class Shield : Item
{
    [SerializeField] ActiveShield activeShield;

    private void OnTriggerEnter2D(Collider2D collision)
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

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        Execute();

        int ownerId = Player.GetComponent<PhotonView>().OwnerActorNr;
        if (photonView.IsMine)
            photonView.RPC("AddInven", RpcTarget.All, "Shield", ownerId);
        gameObject.SetActive(false);
    }

    public override void Execute()
    {
        // playerBehavior의 Use함수를 사용할 때 PlayerMediator의 CurActiveItem의 Use를 불러와서 사용하게 해준다
        // Player에서 CurActiveItem의 형식은 activeBase로 하면 됨
        Player.CurActiveItem = activeShield;                            // player의 CurActiveItem 바인딩
        activeShield.Init(Player);                                      // activeShield의 Player 바인딩
    }
}
