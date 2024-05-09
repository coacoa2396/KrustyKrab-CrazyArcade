using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : 물풍선 
/// </summary>
public class Bubble : PassiveBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);                       // 레이어마스크 체크

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        if (Player.characterStats.Maxbomb == Player.playerStats.Bomb)   // 스크립터블오브젝트에서 설정된 물풍선 최대갯수랑 현재 플레이어의 물풍선 갯수가 같으면
            return;                                                     // 리턴

        Player.playerStats.Bomb++;
    }
}
