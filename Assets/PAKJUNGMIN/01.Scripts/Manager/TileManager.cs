using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin {

    public class TileManager : MonoBehaviour
    {
        [SerializeField] GameObject map;
        public Tile[] tilemap;

        [SerializeField] int lengthX;
        [SerializeField] int lengthY;

        private void Awake()
        {
            tilemap = map.GetComponentsInChildren<Tile>();

            for(int x = 0; x < lengthX; x++)
            {
                for(int y = 0; y < lengthY; y++)
                {
                    tilemap[y].gameObject.name = $"{x},{y}";
                }

            }
        }
    }

}

