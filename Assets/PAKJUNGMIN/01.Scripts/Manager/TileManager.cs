using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin {

    public class TileManager : MonoBehaviour
    {
        static TileManager instance;

        public static TileManager Tile { get { return instance; } }


        [SerializeField] GameObject map;
        public Tile[] tileMap;

        [SerializeField] int lengthX;
        [SerializeField] int lengthY;

        
        private void Awake()
        {

            tileMap = map.GetComponentsInChildren<Tile>();
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
        }
        private void Start()
        {
            if(instance != null) { instance = null; }
            instance = this;
        }

    }

}

