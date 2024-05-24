using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 탈 것 : 우주선
/// </summary>
public class SpaceShip : Item, IAcquirable
{
    // [SerializeField] GameObject spaceShipPrefab; 
    // [SerializeField] GameObject brokenSpaceShipPrefab; 

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

        Player = Player = collision.gameObject.GetComponent<PlayerMediator>();

        // 우주선 프리팹 생성해서 플레이어가 타게 만들어준다
        // 일정 확률로 고장난 우주선이 생성된다
        
        Player.playerInventory.Inven.Add(ItemManager.ItemData.itemDir["SpaceShip"]);
        gameObject.SetActive(false);
    }
}
