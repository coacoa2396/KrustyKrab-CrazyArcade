 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;
using UnityEngine.Events;
/// <summary>
/// Class : 타일 위에 벽 혹은 폭탄이 있는지 판단 담당 클래스
/// </summary>
public class TileObjectDectector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>() || collision.GetComponent<BombCollider>())
        {
            GetComponentInParent<Tile>().OnObject = true;
            GetComponentInParent<Tile>().tileonObject = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseWall>() || collision.GetComponent<BombCollider>())
        {
            if(!GetComponentInParent<Tile>()) { return; } //씬 종료 시 예외 체크.

            GetComponentInParent<Tile>().OnObject = false;
            GetComponentInParent<Tile>().tileonObject = null;    
        }
    }

    //현재까지 발견한 버그 원리.
    /*
     * 정상적인 상황.
     * 
     * 1. 아무것도 없었을 경우 기본 OnObject는 False이다.
     * 2. 폭탄이 놓여진 시점에서 TileObjectDectector가 Tile.OnObject를 true로 바꾼다.
     * 3. 이 후 BombTileCalculator가 Tile.OnObject을 True임을 확인하고 다음 코드로 간다.
     * 
     * 버그가 나는 상황.
     * 1. Tlie의 기본 OnObject는 정상적으로 초기화된 상황에서.
     * 2. 폭탄이 놓여졌을 때, TileObjectDectector가 Tile.OnObject를 바꾸기도 전에
     * 3. BombTileCalculator가 Tile.OnObject를 참조해버리는 상황이 있다. 이럴경우 False가 된다.
     * 4. 
     */

}
