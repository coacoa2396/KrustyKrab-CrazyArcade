using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 Devil
/// </summary>
public class Devil : PassiveBase
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

        Player = Player = collision.gameObject.GetComponent<PlayerMediator>();

        // Player에서 PlayerState를 받아오고

        // Random.Range(0,2)를 해서
        // 0이면 반대입력상태
        // 1이면 물풍선 마구 놓는 상태
    }
}
