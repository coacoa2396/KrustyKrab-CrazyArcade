using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : 롤러스케이트
/// 플레이어의 속도가 1 상승한다
/// </summary>
public class Roller : Item
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

        Player.playerStats.Speed++;

        if (Player.playerStats.Speed > 10f)                         // 플레이어 스피드 상한선
        {
            Player.playerStats.Speed = 10f;
        }

        Destroy(gameObject);
    }
}
