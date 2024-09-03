using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : Needle
/// 물풍선에 갖힌 상태일때 한번 스스로 나올 수 있다
/// </summary>
public class Needle : Item
{
    [SerializeField] ActiveNeedle activeNeedle;

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

        // playerBehavior의 Use함수를 사용할 때 PlayerMediator의 CurActiveItem의 Use를 불러와서 사용하게 해준다
        // Player에서 CurActiveItem의 형식은 activeBase로 하면 됨
        Player.CurActiveItem = activeNeedle;                            // player의 CurActiveItem 바인딩
        activeNeedle.Init(Player);                                      // activeNeedle의 Player 바인딩

        if (collision.gameObject.GetComponent<PhotonView>().IsMine)
            Manager.Sound.PlaySFX("EatItem");

        int ownerId = Player.GetComponent<PhotonView>().OwnerActorNr;
        if (photonView.IsMine)
            photonView.RPC("AddInven", RpcTarget.All, "Needle", ownerId);
        gameObject.SetActive(false);
    }

    
}
