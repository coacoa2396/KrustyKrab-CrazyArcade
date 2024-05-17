using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class : 물줄기 생성 좌표 계산 후 풀링하는 클래스
/// </summary>
public class StreamManager : MonoBehaviour
{
    static StreamManager instance;

    public static StreamManager Stream { get { return instance; } }
    [SerializeField] PooledObject waterStream_Prefab;

    [SerializeField] List<GameObject> tileObjectList;

    private void Start()
    {
        if (instance != null) { instance = null; }
        instance = this;

    }
    /// <summary>
    /// Method : 물줄기 범위 계산
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="power"></param>
    /// 
    Tile FindTile(int x, int y)
    {
        Tile[] tilemap = TileManager.Tile.tileMap;

        foreach (Tile tile in tilemap)
        {
            if (tile.tileNode.posX == x && tile.tileNode.posY == y)
            {
                return tile;
            }
        }
        return null;
    }

    public void RaiseStream(List<Tile> tileList)
    {
        foreach (Tile tile in tileList)
        {
            Manager.Pool.GetPool(waterStream_Prefab, tile.transform.position, Quaternion.identity);
        }
    }
    public void CalculateStream(int x, int y, int power)
    {
        List<Tile> streamList = new List<Tile>();

        Tile[] tilemap = TileManager.Tile.tileMap;

        streamList.Add(FindTile(x, y)); // -> 폭심지 추가


        //동
        for (int q = 0; q <= power; q++)
        {
            if (FindTile(x + q, y) == FindTile(x, y))
            {
                continue;
            }
            if (FindTile(x + q, y) != null)
            {
                if (!FindTile(x + q, y).onObject) // 맨땅
                {
                    streamList.Add(FindTile(x + q, y));
                    continue;
                }
                else if (FindTile(x + q, y).onObject) //타일 위에 무언가가 있었을 경우
                {
                    IBreakable breakable = FindTile(x + q, y).tileonObject.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x + q, y));

                        break;
                    }
                    else if (breakable == null && FindTile(x + q, y).tileonObject.GetComponent<BombTileCalculator>())
                    {     //그것이 물폭탄이었다면               
                        streamList.Add(FindTile(x + q, y));

                        continue;
                    }
                    else //파괴 불가능한 벽일 경우
                    {
                        break;
                    }

                }
            }
        }
        //서
        for (int q = 0; q <= power; q++)
        {
            if (FindTile(x - q, y) == FindTile(x, y))
            {

                continue;
            }
            if (FindTile(x - q, y) != null)
            {
                if (!FindTile(x - q, y).onObject) // 맨땅
                {
                    streamList.Add(FindTile(x - q, y));

                    continue;
                }
                else if (FindTile(x - q, y).onObject) //타일 위에 무언가가 있었을 경우
                {
                    IBreakable breakable = FindTile(x - q, y).tileonObject.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x - q, y));

                        break;
                    }
                    else if (breakable == null && FindTile(x - q, y).tileonObject.GetComponent<BombTileCalculator>())
                    {     //그것이 물폭탄이었다면               
                        streamList.Add(FindTile(x - q, y));

                        continue;
                    }
                    else //파괴 불가능한 벽일 경우
                    {
                        break;
                    }

                }
            }
        }
        //남
        for (int q = 0; q <= power; q++)
        {
            if (FindTile(x, y - q) == FindTile(x, y))
            {
                continue;
            }
            if (FindTile(x, y - q) != null)
            {
                if (!FindTile(x, y - q).onObject) // 맨땅
                {
                    streamList.Add(FindTile(x, y - q));

                    continue;
                }
                else if (FindTile(x, y - q).onObject) //타일 위에 무언가가 있었을 경우
                {
                    IBreakable breakable = FindTile(x, y - q).tileonObject.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x, y - q));

                        break;
                    }
                    else if (breakable == null && FindTile(x, y - q).tileonObject.GetComponent<BombTileCalculator>())
                    {     //그것이 물폭탄이었다면               
                        streamList.Add(FindTile(x, y - q));

                        continue;
                    }
                    else //파괴 불가능한 벽일 경우
                    {
                        break;
                    }

                }
            }
        }
        //북
        for (int q = 0; q <= power; q++)
        {
            if (FindTile(x, y + q) == FindTile(x, y))
            {

                continue;
            }
            if (FindTile(x, y + q) != null)
            {
                if (!FindTile(x, y + q).onObject) // 맨땅
                {
                    streamList.Add(FindTile(x, y + q));

                    continue;
                }
                else if (FindTile(x, y + q).onObject) //타일 위에 무언가가 있었을 경우
                {
                    IBreakable breakable = FindTile(x, y + q).tileonObject.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x, y + q));

                        break;
                    }
                    else if (breakable == null && FindTile(x, y + q).tileonObject.GetComponent<BombTileCalculator>())
                    {     //그것이 물폭탄이었다면               
                        streamList.Add(FindTile(x, y + q));

                        continue;
                    }
                    else //파괴 불가능한 벽일 경우
                    {
                        break;
                    }

                }
            }
        }
        tileObjectList = new List<GameObject>();
        if (streamList.Count > 0)
        {
            foreach(Tile tiles in streamList)
            {
                tileObjectList.Add(tiles.gameObject);
            }
            RaiseStream(streamList);
        }

    }
}
