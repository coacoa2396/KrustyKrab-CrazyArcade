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
    public void LocateDrift(int x, int y, int power)
    {

        Tile bombTile;
        List<Tile> driftList = new List<Tile>();
        Tile[] tilemap = TileManager.Tile.tileMap;

        power++; //<---- 나중에 아래 계산식을 고쳐야한다. 당장은 땜질로 막은 셈이다.

        foreach (Tile tile in tilemap)
        {
            if (tile.tileNode.posX == x && tile.tileNode.posY == y)
            {
                bombTile = tile;
                driftList.Add(bombTile);
                //벽에 가로막혔다면 계산을 끝내야한다.
                //폭심지 기준 동
                for (int q = 0; q < power; q++)
                {
                    if (FindTile(x + q, y) != null)
                    {
                        if (!FindTile(x + q, y).onObject) // 타일 위에 무언가가 없었다면..
                        {
                            driftList.Add(FindTile(x + q, y));
                        }
                        else if (FindTile(x + q, y).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x + q, y).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {
                                
                                driftList.Add(FindTile(x + q, y));
                                break;
                            }
                            else if(breakable == null && FindTile(x + q, y).tileonObject.GetComponent<BombTileCalculator>())
                            {
                                
                                driftList.Add(FindTile(x + q, y));
                                break;
                            }
                            else
                            {
                                
                                break;
                            }

                        }
                    }

                }
                //폭심지 기준 서
                for (int q = 0; q < power; q++)
                {
                    if (FindTile(x - q, y) != null)
                    {
                        if (!FindTile(x - q, y).onObject) //벽이 없었을 경우 
                        {
                            driftList.Add(FindTile(x - q, y));
                        }
                        else if (FindTile(x - q, y).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x - q, y).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {

                                driftList.Add(FindTile(x - q, y));
                                break;
                            }
                            else if (breakable == null && FindTile(x - q, y).tileonObject.GetComponent<BombTileCalculator>())
                            {

                                driftList.Add(FindTile(x - q, y));
                                break;
                            }
                            else
                            {

                                break;
                            }

                        }
                    }

                }
                //폭심지 기준 남
                for (int q = 0; q < power; q++)
                {
                    if (FindTile(x, y - q) != null)
                    {
                        if (!FindTile(x, y - q).onObject) //벽이 없었을 경우 
                        {
                            driftList.Add(FindTile(x, y - q));
                        }
                        else if (FindTile(x, y - q).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x, y - q).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {
                                
                                driftList.Add(FindTile(x, y - q));
                                break;
                            }
                            else if (breakable == null && FindTile(x, y - q).tileonObject.GetComponent<BombTileCalculator>())
                            {
                                
                                driftList.Add(FindTile(x, y - q));
                                break;
                            }
                            else
                            {
                                
                                break;
                            }

                        }
                    }

                }
                //폭심지 기준 북
                for (int q = 0; q < power; q++)
                {
                    if (FindTile(x, y + q) != null)
                    {
                        if (!FindTile(x, y + q).onObject) //벽이 없었을 경우 
                        {
                            driftList.Add(FindTile(x, y + q));
                        }
                        else if (FindTile(x, y + q).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x, y + q).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {
                               
                                driftList.Add(FindTile(x, y + q));
                                break;
                            }
                            else if (breakable == null && FindTile(x, y + q).tileonObject.GetComponent<BombTileCalculator>())
                            {
                                
                                driftList.Add(FindTile(x, y + q));
                                break;
                            }
                            else
                            {
                              
                                break;
                            }

                        }
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
    //타일의 노드를 통해 검색해서 물줄기 폭발이 발생할 타일을 찾아냄.
    //이때 벽일 경우 1칸만 파괴, 파괴할 수 없는 벽은 나오지 않게 해야한다.
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
    public void RaiseDrift(List<Tile> tileList)
    {
        foreach (Tile tile in tileList)
        {
            Manager.Pool.GetPool(waterStream_Prefab, tile.transform.position, Quaternion.identity);
        }
    }
}
