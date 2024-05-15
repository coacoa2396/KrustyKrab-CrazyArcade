using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : 레드데빌
/// 플레이어의 속도를 최대치까지 올리고 물풍선을 밀 수 있게 된다
/// </summary>
public class RedDevil : Item, IAcquirable
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

        Player.playerStats.OwnSpeed = 10f; 

        //if (Player.playerStats.OwnSpeed > 10f)                         // 플레이어 스피드 상한선
        //{
        //    Player.playerStats.OwnSpeed = 10f;
        //}

        // 물풍선을 미는 기능 추가하기 (신발과 같은 기능)
    }
}
