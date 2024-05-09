using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : 물풍선 
/// 플레이어가 한번에 놓을 수 있는 물풍선의 갯수가 1 증가한다
/// </summary>
public class Bubble : PassiveBase
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            Destroy(gameObject);
            return;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        if (Player.characterStats.Maxbomb == Player.playerStats.Bomb)   // 스크립터블오브젝트에서 설정된 물풍선 최대갯수랑 현재 플레이어의 물풍선 갯수가 같으면
            return;                                                     // 리턴

        Player.playerStats.Bomb++;

        Destroy(gameObject);
    }
}
