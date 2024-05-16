using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLocator : MonoBehaviour
{
    int posX;
    int posY;

    public int PosX { get { return posX; } set { posX = value; } }
    public int PosY { get { return posY; } set { posY = value; } }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tile>())
        {
            if (collision.gameObject.GetComponent<Tile>().OnObject) //타일 위에 아무것도 없을 때만
            {
                Tile nowTile = collision.gameObject.GetComponent<Tile>();
                PosX = nowTile.tileNode.posX;
                PosY = nowTile.tileNode.posY;
            }

        }
    }
}
