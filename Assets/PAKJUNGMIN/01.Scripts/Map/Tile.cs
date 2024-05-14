using System;
using UnityEngine;


namespace pakjungmin
{
    public class Tile : MonoBehaviour
    {
        public enum TileStyle 
        {
            Normal, //일반 바닥
            Thorny, //가시밭
            Swamp, //늪지대
        }
        
        public bool isWallhere; //이 타일 위에 벽이 세워짐 여부
        [SerializeField] public GameObject wall;
        [SerializeField] public TileNode tileNode; //타일의 좌표.
        public TileStyle tileStyle; //바닥의 종류

        public bool OnWall { get { return isWallhere; } set { isWallhere = value; } }
        
    }
    [Serializable]
    public struct TileNode
    {
        public int posX;
        public int posY;
    }



}

