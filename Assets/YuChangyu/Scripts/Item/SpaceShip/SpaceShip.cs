using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 탈 것 : 우주선
/// </summary>
public class SpaceShip : PassiveBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            Destroy(gameObject);
            return;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = Player = collision.gameObject.GetComponent<PlayerMediator>();

        // 우주선 프리팹 생성해서 플레이어가 타게 만들어준다
    }
}
