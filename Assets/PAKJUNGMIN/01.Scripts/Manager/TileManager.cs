using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace pakjungmin { 


    /// <summary>
    /// Class : 타일 매니저
    /// </summary>
    /// 
    /* 사용법
     * 0. x,y에 존재하는 타일의 정보 가져오는 방법 -->  TileManager.Tile.tileDic["{x},{y}"]; 
     * 
     * 
     * 작동방식 개괄
     * 0. 시작 시 맵의 왼쪽 최하단 타일부터 오른쪽 최상단 타일을 참조해 (0,0)부터 시작해 (15,13)까지 모든 타일의 이름을 순서대로 재설정.
     * 1. 타일 딕셔너리에 모든 타일을 삽입하고 Key를 타일 오브젝트의 이름으로 정한다.이는 타일의 좌표로 키를 설정함으로써,타일을 쉽게 찾기 위함이다.
     * 
     */
    public class TileManager : MonoBehaviour
    {
        static TileManager instance;
        public static TileManager Tile { get { return instance; } }
        [SerializeField] GameObject map; //모든 타일맵을 가진 게임 오브젝트

        public Dictionary<string, Tile> tileDic; //맵의 모든 타일 데이터 삽입된 타일 딕셔너리
        [SerializeField] int lengthX; // 타일 맵의 가로 크기
        [SerializeField] int lengthY; // 타일 맵의 세로 크기

        
        private void Awake()
        {
            tileDic = new Dictionary<string, Tile>();

            Tile[] tileMap = map.GetComponentsInChildren<Tile>();

            int x = 0;
            int y = 0;
            foreach(Tile tile in tileMap)
            {            
                tile.gameObject.name = $"{x},{y}";
                tile.tileNode.posX = x;
                tile.tileNode.posY = y;
                x++;
                if(x >= lengthX)
                {
                    y++;
                    x = 0;
                }
            }
            foreach(Tile tile in tileMap)
            {
                tileDic.Add($"{tile.gameObject.name}", tile);
            }
        }
        private void Start()
        {
            if(instance != null) { instance = null; }
            instance = this;
        }

    }

}

