using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : Owl
/// </summary>
public class Owl : Item, IAcquirable
{
    // [SerializeField] GameObject owlPrefab;

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

        // 부엉이 프리팹을 생성해서 플레이어가 타도록 만들어준다

        Player.playerInventory.Inven.Add(ItemManager.ItemData.itemDir["Owl"]);
        gameObject.SetActive(false);
    }
}
