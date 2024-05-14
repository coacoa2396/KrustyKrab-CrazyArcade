using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : Dart
/// </summary>
public class Dart : Item, IAcquirable
{
    [SerializeField] ActiveDart activeDart;

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
        Player.CurActiveItem = activeDart;                            // player의 CurActiveItem 바인딩
        activeDart.Init(Player);                                      // activeDart의 Player 바인딩
    }
}
