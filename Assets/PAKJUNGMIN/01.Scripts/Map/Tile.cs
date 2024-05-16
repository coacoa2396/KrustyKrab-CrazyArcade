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
        
        public bool onObject; //이 타일 위에 벽 혹은 폭탄이 설치됨 여부.
        

        [SerializeField] public GameObject tileonObject;

        [SerializeField] public TileNode tileNode; //타일의 좌표.

        public TileStyle tileStyle; //바닥의 종류

        public bool OnObject { get { return onObject; } set { onObject = value; } }
        
    }
    [Serializable]
    public struct TileNode
    {
        public int posX;
        public int posY;
    }



}

