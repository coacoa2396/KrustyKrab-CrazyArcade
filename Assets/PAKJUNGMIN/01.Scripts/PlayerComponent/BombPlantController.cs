using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class : PlayerBehavoir에서 폭탄 설치 명령을 받아, 실제 폭탄 설치를 담당하는 클래스.
/// </summary>
public class BombPlantController : MonoBehaviour
{
    PlayerMediator playerMediator;
    /*
     * 0. 플레이어의 현재 폭탄 개수만큼 현재 설치가능한 폭탄 개수 변수를 정한다. 
     * 1. 이 변수는 플레이어의 현재 폭탄 개수가 최대치이다.
     * 2. 폭탄을 설치하면, 이 변수는 1씩 줄어든다.
     * 3. 일정 시간을 통해, 변수를 1씩 증가시킨다.
     * 4. 이 변수가 0일 경우 폭탄 설치가 불가능하다.
     */

    [SerializeField] int bombChance;
    [Header("폭탄 설치가능 시간 주기 : float")]
    [SerializeField] float chanceTimer; //기본값 3초
    float ownChanceTimer;
    Coroutine chanceCoroutine;

    public int BombChance { get { return bombChance; }
        set
        { 
            bombChance = value;
            if(bombChance >= playerMediator.playerStats.OwnBomb)
            {
                bombChance = playerMediator.playerStats.OwnBomb;
            }
        } 
    }

    IEnumerator GetChance()
    {
        ownChanceTimer = chanceTimer;
        while (true)
        {
            ownChanceTimer -= Time.deltaTime;
            yield return null;
            if (ownChanceTimer <= 0)
            {
                BombChance++;
                break;
            }
        }  
       
    }
    private void Update()
    {
        if (bombChance < playerMediator.playerStats.OwnBomb)
        {
            chanceCoroutine = StartCoroutine(GetChance());
        }
    }
    private void Awake()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }
    private void Start()
    {
        bombChance = playerMediator.playerStats.OwnBomb;
    }
    public void PlantBomb(Bomb waterBomb,Vector3 BombPos)
    {
        if(bombChance <= 0) { return; }

        if(playerMediator.floorChecker.nowTile.OnObject)
        {
            if (playerMediator.floorChecker.nowTile.tileonObject.GetComponent<BombLocator>())
            {
                playerMediator.playerSkill.Throw();
                return;
            }
            return;
        }

        PooledObject pooledbomb = Manager.Pool.GetPool(waterBomb, BombPos, Quaternion.identity);
        Bomb bomb = (Bomb)pooledbomb;
        bomb.bombPower = playerMediator.playerStats.OwnPower;
        bombChance--;
    }
}
