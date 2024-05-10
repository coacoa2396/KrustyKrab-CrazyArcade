using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class : 물줄기 총괄 매니저.
/// </summary>
public class DriftManager: MonoBehaviour
{
    static DriftManager instance;

    public static DriftManager Drift { get { return instance; } }

    [SerializeField] PooledObject driftprefab;

    private void Start()
    {
        if (instance != null) { instance = null; }
        instance = this;
        
    }
    /// <summary>
    /// Method : 폭발 범위 계산
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="power"></param>
    public void LocateDrift(int x,int y,int power)
    {
       Tile bombTile;
       List<Tile> driftList = new List<Tile>();
       Tile[] tilemap = TileManager.Tile.tileMap;
       foreach (Tile tile in tilemap)
       {
            if (tile.tileNode.posX == x && tile.tileNode.posY == y)
            {
                bombTile = tile;
                driftList.Add(bombTile);

                //폭심지 기준 동
                for (int q = 0; q < power; q++)
                {
                    if (FindTile(x + q, y) != null)
                    { driftList.Add(FindTile(x + q, y)); }

                }
                //폭심지 기준 서
                for (int q = 0; q < power; q++)
                {

                    if (FindTile(x - q, y) != null)
                    {
                        driftList.Add(FindTile(x - q, y));
                    };

                }
                //폭심지 기준 남
                for (int q = 0; q < power; q++)
                {
                    if (FindTile(x, y - q) != null)
                    {
                        driftList.Add(FindTile(x, y - q));
                    }

                }
                //폭심지 기준 북
                for (int q = 0; q < power; q++)
                {

                    if (FindTile(x, y + q) != null)
                    {
                        driftList.Add(FindTile(x, y + q));
                    }

                }
                break;
            }
        }
        if (driftList.Count > 0)
       {
           RaiseDrift(driftList);
       }
       
    }
    //타일의 노드를 통해 검색해서 타일을 찾아냄.
    Tile FindTile(int x,int y)
    {
        Tile[] tilemap = TileManager.Tile.tileMap;

        foreach(Tile tile in tilemap)
        {
            if(tile.tileNode.posX == x && tile.tileNode.posY == y)
            {
                return tile;
            }
        }

        return null;
    }

    public void RaiseDrift(List<Tile> tileList)
    {
        foreach(Tile tile in tileList)
        {
            Manager.Pool.GetPool(driftprefab,tile.transform.position,Quaternion.identity);
        }
    }
}
