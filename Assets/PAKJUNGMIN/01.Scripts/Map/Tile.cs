using System;
using UnityEngine;


namespace pakjungmin
{
    /// <summary>
    /// Class : 타일 클래스. TileObjectDectector의 부모 오브젝트.
    /// </summary>
    /// 

    /* 자식클래스 목록 :
     * 0. TileObjectDectector 
     */


    public class Tile : MonoBehaviour
    {
        public bool onObject; // 타일 위에 벽 or 폭탄 존재 여부    
        public GameObject objectOnTile;  //타일 위에 존재하는 오브젝트명
        public TileNode tileNode;  //타일 좌표(x,y) 구조체

        public bool OnObject { get { return onObject; } set { onObject = value; } }
        
    }
    /// <summary>
    /// Struct : 맵의 타일 기준(X,Y) 좌표 구조체
    /// 맵의 가장의 왼쪽 최하단 타일이 (0,0) 원점
    /// </summary>
    [Serializable]
    public struct TileNode
    {
        public int posX;
        public int posY;
    }



}

