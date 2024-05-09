using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin {

    public class TileManager : MonoBehaviour
    {
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
                Debug.Log($"{x},{y}");
                y++;
                if(y >= lengthY)
                {
                    x++;
                    y = 0;
                }
            }
        }
    }

}

