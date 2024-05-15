using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class : PlayerBehavoir에서 폭탄 설치 명령을 받아, 실제 폭탄 설치를 담당하는 클래스.
/// </summary>
public class PlayerBombPlantController : MonoBehaviour
{
    PlayerMediator playerMediator;

    /*
     * 먼저 플레이어의 폭탄 개수가 정해지고, 폭탄을 사용하면
     * 폭탄 소지 개수가 하나씩 줄어들며, 일정시간이 지날때마다
     * 1개씩 다시 증가하는 로직으로 짜야할 것 같다.
     * 
     */
    IEnumerator SetBombDelay()
    {

        return null;
    }

    private void Awake()
    {
        playerMediator.GetComponentInParent<PlayerMediator>();
    }
    public void OnPlant(PooledObject waterBomb,Vector3 BombPos)
    {
        //플레이어가 물풍선 프리팹과 물풍선이 놓일 좌표를 알고 있어야함.
        Manager.Pool.GetPool(waterBomb, BombPos, Quaternion.identity);
    }
}
