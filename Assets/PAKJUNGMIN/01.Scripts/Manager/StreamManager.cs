using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class : 물줄기 생성 좌표 계산 후 풀링하는 클래스
/// </summary>
/// 
/*
 * 작동방식 개괄
 * 
 * 0. CalculateStream()에서 매개변수 x,y을 확인하고  x,y의 타일좌표를 폭심지로 정하고, 이를 물줄기 생성 리스트에 삽입한다.
 * 
 * 1. 매개변수 power의 숫자만큼 폭심지의 동쪽 타일들을 확인한다.
 * 2. 확인한 타일에 파괴가능한 벽,파괴 불가능한 벽,폭탄이 있는지 여부를 확인한다.
 * 3. 파괴가능한 벽이면, 물줄기 생성 리스트에 삽입,그 후 계산 종료. 
 * 4. 파괴불가능한 벽이면, 계산 종료.
 * 5. 아무것도 없는 타일이면, 물줄기 생성 리스트에 삽입, 다음 계산으로 넘어간다.
 * 6. 물폭탄이면 물줄기 생성 리스트에 삽입, 다음 계산으로 넘어간다.
 * 
 * 7. 나머지 서,남,북쪽에도 1~6번의 계산을 적용한다.
 * 8. RasiseStream의 매개변수에 물줄기 생성 리스트를 넘긴다.
 * 
 * 4. RaiseStream()가 리스트를 확인하여, 실제로 물줄기를 풀러에서 GetPool 시킨다.
*/
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
    Tile FindTile(int x, int y)
    {
        if (TileManager.Tile.tileDic.ContainsKey($"{x},{y}"))
        {
            return TileManager.Tile.tileDic[$"{x},{y}"];
        }
        else
        {
            return null;
        }
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

        streamList.Add(FindTile(x, y)); // -> 폭심지 추가

        //동
        for (int q = 0; q <= power; q++)
        {
            if((q == 0) || (FindTile(x+q,y) == null))
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
                    IBreakable breakable = FindTile(x + q, y).objectOnTile.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x + q, y));

                        break;
                    }
                    else if (breakable == null && FindTile(x + q, y).objectOnTile.GetComponent<BombStreamDectector>())
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
            if (q == 0 || (FindTile(x - q, y) == null))
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
                    IBreakable breakable = FindTile(x - q, y).objectOnTile.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x - q, y));

                        break;
                    }
                    else if (breakable == null && FindTile(x - q, y).objectOnTile.GetComponent<BombStreamDectector>())
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
            if (q == 0 || (FindTile(x, y-q) == null))
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
                    IBreakable breakable = FindTile(x, y - q).objectOnTile.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x, y - q));

                        break;
                    }
                    else if (breakable == null && FindTile(x, y - q).objectOnTile.GetComponent<BombStreamDectector>())
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
            if (q == 0 || (FindTile(x, y + q) == null))
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
                    IBreakable breakable = FindTile(x, y + q).objectOnTile.GetComponent<IBreakable>();

                    if (breakable != null) //파괴가능한 벽이었을 경우
                    {
                        streamList.Add(FindTile(x, y + q));

                        break;
                    }
                    else if (breakable == null && FindTile(x, y + q).objectOnTile.GetComponent<BombStreamDectector>())
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
        if (streamList.Count > 0)
        {
            RaiseStream(streamList);
        }

    }
}
