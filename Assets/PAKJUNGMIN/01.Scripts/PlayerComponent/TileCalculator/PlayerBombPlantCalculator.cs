using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class : PlayerBehavoir에서 폭탄 설치 명령을 받아, 실제 폭탄 설치를 담당하는 클래스.
/// </summary>
public class PlayerBombPlantCalculator : MonoBehaviourPun
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

    public int BombChance
    {
        get { return bombChance; }
        set
        {
            if (photonView.IsMine == false) //권새롬 추가 --> 내가 아닌 다른사람이 바꾸면 곤란해짐.(동기화안됨)
                return;
            bombChance = value;
            if (bombChance >= playerMediator.playerStats.OwnBomb)
            {
                bombChance = playerMediator.playerStats.OwnBomb;
            }
            photonView.RPC("BombChanceChange", RpcTarget.Others, bombChance);
        }
    }
    //킥이나 아이템 사용 시 잠깐 폭탄 설치 못하게 만드는 메소드.
    public void WaitBombPlant()
    {
        ownChanceTimer = 1.3f;
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
    private void FixedUpdate()
    {
        if (BombChance < playerMediator.playerStats.OwnBomb)
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
        BombChance = playerMediator.playerStats.OwnBomb;
    }
    public void PlantBomb(Bomb waterBomb, Tile tile)
    {
        if (BombChance <= 0) { return; }

        if (tile.OnObject) { return; }

       
        Vector3 tilePos = TileManager.Tile.tileDic[$"{tile.tileNode.posX},{tile.tileNode.posY}"].transform.position;
       
        PooledObject pooledbomb = Manager.Pool.GetPool(waterBomb, tilePos, Quaternion.identity);
        Bomb bomb = (Bomb)pooledbomb;

        bomb.PosX = tile.tileNode.posX;
        bomb.PosY = tile.tileNode.posY;

        bomb.bombPower = playerMediator.playerStats.OwnPower;
        BombChance--;
    }

    [PunRPC]
    public void BombChanceChange(int count)
    {
        bombChance = count;
    }

}
