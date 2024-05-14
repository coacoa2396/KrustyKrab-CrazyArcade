using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 지속시간 동안 모든 공격을 방어한다
/// </summary>
public class Shield : Item
{
    [SerializeField] ActiveShield activeShield;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            Destroy(gameObject);
            return;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = collision.gameObject.GetComponent<PlayerMediator>();

        // playerBehavior의 Use함수를 사용할 때 PlayerMediator의 CurActiveItem의 Use를 불러와서 사용하게 해준다
        // Player에서 CurActiveItem의 형식은 activeBase로 하면 됨
        Player.CurActiveItem = activeShield;                            // player의 CurActiveItem 바인딩
        activeShield.Init(Player);                                      // activeShield의 Player 바인딩

        Destroy(gameObject);
    }
}
