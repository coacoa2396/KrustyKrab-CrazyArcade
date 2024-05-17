using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : BaseWall, IBreakable
{
    /*
     * Object : 벽 속의 아이템만 구현.
     * 
     * 1. 맵이 로드되면 벽이 깔리는 동시에 랜덤으로 벽에 아이템을 넣는다.
     * 2. 벽이 파괴되면 아이템이 그 자리에 생성된다.
     * 
     * 
     * 
     */

    [SerializeField] public GameObject randomItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Stream>())
        {
            gameObject.SetActive(false);
            ItemSpawner.Inst.SpawnItem(transform.position);
        }
    }
}
