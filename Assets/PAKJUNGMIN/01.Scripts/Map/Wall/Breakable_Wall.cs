using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Wall : BaseWall, IBreakable
{

    public void OnBreak()
    {
       // 랜덤 확률로 아이템 생성 루틴
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Drift>())
        {
            gameObject.SetActive(false);
        }
    }
}
