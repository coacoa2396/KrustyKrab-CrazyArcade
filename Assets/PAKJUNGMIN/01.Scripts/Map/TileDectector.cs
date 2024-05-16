 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;
/// <summary>
/// Class : 타일 위에 벽이 있는가 여부 판단
/// </summary>
public class Tile_WallDectector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>() || collision.GetComponent<BombLocator>())
        {
            GetComponentInParent<Tile>().OnObject = true;
            GetComponentInParent<Tile>().tileonObject = collision.gameObject;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>() || collision.GetComponent<BombLocator>())
        {
            if(!GetComponentInParent<Tile>()) { return; } //씬 종료 시 예외 체크.

            GetComponentInParent<Tile>().OnObject = false;
            GetComponentInParent<Tile>().tileonObject = null;    
        }
    }

}
