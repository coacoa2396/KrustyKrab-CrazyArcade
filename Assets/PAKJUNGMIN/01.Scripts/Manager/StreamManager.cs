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
    /// Method : 물줄기 범위 계산
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="power"></param>
    public void CaculateStreamPos(int x, int y, int power)
    {

        Tile bombTile;
        List<Tile> streamList = new List<Tile>();
        Tile[] tilemap = TileManager.Tile.tileMap;

        foreach (Tile tile in tilemap)
        {

            if (tile.tileNode.posX == x && tile.tileNode.posY == y)
            {
                bombTile = tile;
                streamList.Add(bombTile);
                Debug.Log($"폭심지 : {x},{y} 삽입");

                //동
                for (int q = 0; q <= power; q++)
                {
                    if (FindTile(x + q, y) == FindTile(x, y))
                    {
                        Debug.Log("같은 타일 계산 제외");
                        continue;
                    }
                    if (FindTile(x + q, y) != null)
                    {
                        if (!FindTile(x + q, y).onObject) // 맨땅
                        {
                            streamList.Add(FindTile(x + q, y));
                            Debug.Log($"동1: {x + q},{y} 삽입");
                            continue;
                        }
                        else if (FindTile(x + q, y).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x + q, y).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {
                                streamList.Add(FindTile(x + q, y));
                                Debug.Log($"동2: {x + q},{y} 삽입");
                                continue;
                            }
                            else if (breakable == null && FindTile(x + q, y).tileonObject.GetComponent<BombTileCalculator>())
                            {     //그것이 물폭탄이었다면               
                                streamList.Add(FindTile(x + q, y));
                                Debug.Log($"동3 : {x + q},{y} 삽입");
                                continue;
                            }
                            else //파괴 불가능한 벽일 경우
                            {
                                break;
                            }

                        }
                    }
                }
                //폭심지 기준 서
                for (int q = 0; q <= power; q++)
                {
                    if (FindTile(x - q, y) == FindTile(x, y))
                    {
                        Debug.Log("같은 타일 계산 제외");
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

                                continue;
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
                        Debug.Log("같은 타일 계산 제외");
                        continue;
                    }
                    if (FindTile(x, y - q) != null)
                    {
                        if (!FindTile(x, y - q).onObject) // 맨땅
                        {
                            streamList.Add(FindTile(x, y - q));
                            Debug.Log($"동1: {x + q},{y} 삽입");
                            continue;
                        }
                        else if (FindTile(x, y - q).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x, y - q).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {
                                streamList.Add(FindTile(x, y - q));
                                Debug.Log($"동2: {x + q},{y} 삽입");
                                continue;
                            }
                            else if (breakable == null && FindTile(x, y - q).tileonObject.GetComponent<BombTileCalculator>())
                            {     //그것이 물폭탄이었다면               
                                streamList.Add(FindTile(x, y - q));
                                Debug.Log($"동3 : {x + q},{y} 삽입");
                                continue;
                            }
                            else //파괴 불가능한 벽일 경우
                            {
                                break;
                            }

                        }
                    }
                }
                //폭심지 기준 북
                for (int q = 0; q <= power; q++)
                {
                    if (FindTile(x, y + q) == FindTile(x, y))
                    {
                        Debug.Log("같은 타일 계산 제외");
                        continue;
                    }
                    if (FindTile(x, y + q) != null)
                    {
                        if (!FindTile(x, y + q).onObject) // 맨땅
                        {
                            streamList.Add(FindTile(x, y + q));
                            Debug.Log($"동1: {x + q},{y} 삽입");
                            continue;
                        }
                        else if (FindTile(x, y + q).onObject) //타일 위에 무언가가 있었을 경우
                        {
                            IBreakable breakable = FindTile(x, y + q).tileonObject.GetComponent<IBreakable>();

                            if (breakable != null) //파괴가능한 벽이었을 경우
                            {
                                streamList.Add(FindTile(x, y + q));
                                Debug.Log($"동2: {x + q},{y} 삽입");
                                continue;
                            }
                            else if (breakable == null && FindTile(x, y + q).tileonObject.GetComponent<BombTileCalculator>())
                            {     //그것이 물폭탄이었다면               
                                streamList.Add(FindTile(x, y + q));
                                Debug.Log($"동3 : {x + q},{y} 삽입");
                                continue;
                            }
                            else //파괴 불가능한 벽일 경우
                            {
                                break;
                            }

                        }
                    }
                }

                if (streamList.Count > 0)
                {
                    RaiseStream(streamList);
                }
            }
            //타일의 노드를 통해 검색해서 물줄기 폭발이 발생할 타일을 찾아냄.
            //이때 벽일 경우 1칸만 파괴, 파괴할 수 없는 벽은 나오지 않게 해야한다.
        }
    }
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
        Debug.Log($"tileList.Count : {tileList.Count}");
        foreach (Tile tile in tileList)
        {
            Manager.Pool.GetPool(waterStream_Prefab, tile.transform.position, Quaternion.identity);
        }
    }
}
