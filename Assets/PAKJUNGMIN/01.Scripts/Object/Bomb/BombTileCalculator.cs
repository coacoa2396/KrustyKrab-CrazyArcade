using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Class : 폭탄의 좌표(타일 좌표 기준) 저장 담당
/// </summary>
public class BombTileData : MonoBehaviour
{
    //[SerializeField] public TileNode nowTile;

    //UnityAction OnPlanted;

    //private void Awake()
    //{
    //    OnPlanted += CalculatePos;
    //}
    //private void OnEnable()
    //{
    //    OnPlanted?.Invoke();
    //}
    ////private void OnTriggerStay2D(Collider2D collision)
    ////{
    ////    if (collision.gameObject.GetComponent<Tile>() == null) { return; }

    ////    if (collision.gameObject.GetComponent<Tile>().OnObject)
    ////    {
    ////        CalculatePos();
    ////    }

    ////}

    //void CalculatePos()
    //{
    //   // nowTile = collision.GetComponent<Tile>().tileNode;
    //    Debug.Log($"{transform.parent.name}`s NowTile : ({nowTile.posX},{nowTile.posY})");
    //    GetComponentInParent<Bomb>().PosX = nowTile.posX;
    //    GetComponentInParent<Bomb>().PosY = nowTile.posY;
    //}

}
