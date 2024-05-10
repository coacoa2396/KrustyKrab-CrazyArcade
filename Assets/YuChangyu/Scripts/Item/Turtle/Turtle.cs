using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : PassiveBase
{
    // [SerializeField] GameObject turtlePrefab;
    // [SerializeField] GameObject pirateTurtlePrefab;

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

        // 거북이 프리팹 생성해서 플레이어가 타게 만들어준다
        // 일정 확률로 속도가 매우 빠른 해적거북이가 생성된다
    }
}
