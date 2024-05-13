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
        if (collision.GetComponent<BaseWall>())
        {
            GetComponentInParent<Tile>().OnWall = true;
            GetComponentInParent<Tile>().wall = collision.gameObject;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>())
        {
            GetComponentInParent<Tile>().OnWall = false;
            GetComponentInParent<Tile>().wall = null;
           
        }
    }

}
