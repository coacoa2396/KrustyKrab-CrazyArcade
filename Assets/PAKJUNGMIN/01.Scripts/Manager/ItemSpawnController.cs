using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawnController : MonoBehaviour
{
    static ItemSpawnController instance;

    public static ItemSpawnController Inst {  get { return instance; } }

    private void Awake()
    {
        if(instance != null) { instance = null; }
        instance = this;
    }

    private void Start()
    {
        Tile[] tilemap = TileManager.Tile.tileMap;

        foreach(Tile tile in tilemap)
        {
            if(tile.wall != null && tile.wall is Breakable_Wall) 
            {
                //Breakable_Wall breakable_Wall = (Breakable_Wall)tile.wall;
            }
        }
    }

    /// <summary>
    /// Method : 랜덤 확률로 아이템 넣기.
    /// </summary>
    void PushItem()
    {

    }
}
