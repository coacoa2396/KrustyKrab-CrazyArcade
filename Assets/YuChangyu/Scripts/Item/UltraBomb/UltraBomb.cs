using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 UltraBomb
/// 플레이어의 파워가 최대치까지 상승한다
/// </summary>
public class UltraBomb : PassiveBase
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            Destroy(gameObject);
            return;
        }

        if (!CheckPlayer(collision.gameObject))
            return;                                                         // 레이어마스크 체크

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        if (Player.characterStats.MaxPower == Player.playerStats.Power)     // 스크립터블오브젝트에서 설정된 물풍선 최대갯수랑 현재 플레이어의 물풍선 갯수가 같으면
            return;                                                         // 리턴

        Player.playerStats.Power = Player.characterStats.MaxPower;

        Destroy(gameObject);
    }
}
