using System;
using UnityEditor.Experimental.GraphView;
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
        bool isWallhere; //이 타일 위에 벽이 세워짐 여부
        [SerializeField] public TileNode tileNode; //타일의 좌표.

        TileStyle tileStyle; //바닥의 종류
        
    }
    [Serializable]
    public struct TileNode
    {
        public int posX;
        public int posY;
    }


}

