using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 아이템 : 물병
/// 플레이어의 파워가 1 상승한다
/// </summary>
public class Fluid : Item, IAcquirable
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            if (WaterProof <= 0)
            {
                Destroy(gameObject);
                return;
            }
            WaterProof--;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        //if (Player.characterStats.MaxPower == Player.playerStats.Power)         // 플레이어의 최대 파워와 현재 파워가 같다면
        //    return;                                                             // 리턴
        // 박정민 추가 : PlayerStat에서 최대 스탯 안 넘어가는 구현했기에 주석 처리.

        Player.playerStats.OwnPower++; //박정민 추가 : Power ->OwnPower로 변경

        Player.playerInventory.Inven.Add(ItemDataManager.ItemData.itemDir["Fluid"]);
        gameObject.SetActive(false);
    }
}
