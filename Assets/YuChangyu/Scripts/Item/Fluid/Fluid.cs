using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 아이템 : 물병
/// </summary>
public class Fluid : PassiveBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        if (Player.characterStats.MaxPower == Player.playerStats.Power)         // 플레이어의 최대 파워와 현재 파워가 같다면
            return;                                                             // 리턴

        Player.playerStats.Power++;

        Destroy(gameObject);
    }
}
