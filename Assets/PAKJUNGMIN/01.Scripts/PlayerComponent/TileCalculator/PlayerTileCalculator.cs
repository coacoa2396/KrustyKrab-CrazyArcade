using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;
using System.Linq;
using Unity.VisualScripting;

namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어가 현재 서 있는 발판과 폭탄 설치 위치 등을 계산한다.
    /// </summary>
    /// 

    /*
     * 작동방식 개괄.
     * 0. 플레이어와 충돌중인 모든 Tile 오브젝트를 인접타일 리스트에 삽입한다. 만일 충돌에서 벗어났다면 그 타일은 리스트에서 삭제한다.
     * 1. 실시간으로 인접타일리스트의 각각 타일의 위치와 플레이어의 위치의 거리를 계산하고, 그 결과값들을 distanceList에 삽입한다.
     * 2. distanceList의 최솟값을 반환하여, 이 값을 플레이어가 지금 서 있는 타일이라고 취급하고, nowTile에 할당한다.
     * 3. 이 후 dinstanceList의 모든 요소를 없앤다.
     */


    public class PlayerTileCalculator : MonoBehaviour
    {
        public Tile nowTile; //현재 플레이어가 서 있는 타일.
        [SerializeField] List<Tile> touchedTiles = new List<Tile>(); // 인접타일 리스트
        [SerializeField] List<float> distanceList = new List<float>();



        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Tile>())
            {
                AddList(collision);
                LocatePlayer();
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Tile>())
            {
                AddList(collision);
                LocatePlayer();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Tile>())
            {
                RemoveList(collision);
                LocatePlayer(); 
            }
        }

        void AddList(Collider2D collision)
        {
            if (touchedTiles.Contains(collision.gameObject.GetComponent<Tile>())) { return; }
            touchedTiles.Add(collision.gameObject.GetComponent<Tile>());
        }

        void RemoveList(Collider2D collision)
        {
            touchedTiles.Remove(collision.gameObject.GetComponent<Tile>());
        }

        //Method : 플레이어의 위치와 리스트 안 타일의 정점들의 거리를 각각 계산하여, 제일 가까운 타일을 현재 타일로 취급한다.
        void LocatePlayer()
        {
            if(touchedTiles.Count == 1)
            { 
                nowTile = touchedTiles[0];
                return;
            }
           
            Vector2 playerPos = (Vector2)gameObject.GetComponent<CircleCollider2D>().offset;
            foreach (Tile tile in touchedTiles)
            {
                if(tile == null)
                {
                    touchedTiles.Remove(tile);
                    continue;
                }
                distanceList.Add(Vector2.Distance((Vector2)tile.transform.position, playerPos));
            }
            if (nowTile == null || touchedTiles == null) { return; }
            if(distanceList.Count<=0) { return; }
            nowTile = touchedTiles[distanceList.IndexOf(distanceList.Min())];
            distanceList.Clear();
        }
    }
}
