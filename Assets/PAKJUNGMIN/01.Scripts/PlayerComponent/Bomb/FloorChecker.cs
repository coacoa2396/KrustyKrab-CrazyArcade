using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;

namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어가 현재 서 있는 발판과 폭탄 설치 위치 등을 계산한다.
    /// </summary>
    public class FloorChecker : MonoBehaviour
    {
        public Tile nowTile; //현재 플레이어가 서 있는 타일 == 인접타일 리스트 중 가장 가까운 거리의 타일.
        List<Tile> touchedTiles = new List<Tile>(); // 인접 타일 리스트
        public void OnTriggerEnter2D(Collider2D collision)
        {
            AddList(collision);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            AddList(collision);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            RemoveList(collision);
        }
        void AddList(Collider2D collision)
        {
            //인접한 타일을 인접타일 리스트에 추가
        }
        void RemoveList(Collider2D collision)
        {
            //벗어난 타일을 인접타일 리스트에서 제거.
        }
        //Method : 플레이어의 위치와 리스트 안 타일의 정점들의 거리를 각각 계산하여, 제일 가까운 타일을 현재 타일로 취급한다.
        void LocatePlayer()
        {
            //플레이어의 위치와 리스트 안 타일의 정점을 계산하여, 제일 가까운 타일을 현재 타일로 취급하는 로직.
        }

    }
}
