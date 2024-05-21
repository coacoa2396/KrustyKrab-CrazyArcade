using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseWall : MonoBehaviour
{
    public TileNode tileNode; // 맵의 타일 기준 (X,Y) 좌표 구조체

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tile>())
        {
            this.tileNode = collision.GetComponent<Tile>().tileNode;
        }
    }

}
