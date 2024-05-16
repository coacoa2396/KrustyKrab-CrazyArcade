using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : Item,IAcquirable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckWater(collision.gameObject))
        {
            if (WaterProof <= 0)
            {
                Destroy(gameObject);
                return;
            }
            WaterProof--;
        }

        if (!CheckPlayer(collision.gameObject))
            return;

        Player = Player = collision.gameObject.GetComponent<PlayerMediator>();

        // 플레이어 스킬에서 던지기 기능 활성화 시키기

        Destroy(gameObject);
    }
}
