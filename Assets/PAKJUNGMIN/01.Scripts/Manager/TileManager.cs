using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace pakjungmin {

    public class TileManager : MonoBehaviour
    {
        static TileManager instance;

        public static TileManager Tile { get { return instance; } }


        [SerializeField] GameObject map;
        //public Tile[] tileMap;
        public Dictionary<string, Tile> tileDic;


        [SerializeField] int lengthX;
        [SerializeField] int lengthY;

        
        private void Awake()
        {
            tileDic = new Dictionary<string, Tile>();

            Tile[] tileMap = map.GetComponentsInChildren<Tile>();
            //tileMap = map.GetComponentsInChildren<Tile>(); ^ Tile[] 지역 변수화 
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
                Debug.Log($"{tile.gameObject.name} Added.");
            }
        }
        private void Start()
        {
            if(instance != null) { instance = null; }
            instance = this;
        }

    }

}

