 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;
/// <summary>
/// Class : 타일 위에 벽 혹은 폭탄이 있는지 판단 담당 클래스
/// </summary>
public class TileObjectDectector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>() || collision.GetComponent<BombTileCalculator>())
        {
            GetComponentInParent<Tile>().OnObject = true;
            GetComponentInParent<Tile>().tileonObject = collision.gameObject;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>() || collision.GetComponent<BombTileCalculator>())
        {
            if(!GetComponentInParent<Tile>()) { return; } //씬 종료 시 예외 체크.

            GetComponentInParent<Tile>().OnObject = false;
            GetComponentInParent<Tile>().tileonObject = null;    
        }
    }

}
