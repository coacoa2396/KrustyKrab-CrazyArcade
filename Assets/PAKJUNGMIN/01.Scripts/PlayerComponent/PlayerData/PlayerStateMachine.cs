using pakjungmin;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerMediator playerMediator;

    public UnityAction<PlayerStateMachine> OnDied;

    [SerializeField] BubbleCollider bubbleCollider;

    public enum State
    {
        Alive,
        Trapped,
        Die,
        Devil
    }
    [Header("물방울 갇혔을 때, 익사 시간")]
    [SerializeField] float maxDrownTime;
    public float DrownTimer { get { return maxDrownTime; } } // 익사시간 프로퍼티 추가, 애니메이션에서 사용하기 위함 -> 유찬규 추가
    [SerializeField] float ownDrownTime;

    Coroutine coroutinedrown;
    bool Iscoroutine;

    [Header("플레이어의 상태")]
    public State ownState;


    [Header("데빌 상태 관련")]
    Coroutine coroutinedevil;
    [SerializeField] public float maxDevilTime;
    public float ownDevilTime;




    IEnumerator DrownCoroutine()
    {
        Iscoroutine = true;
        while (true)
        {
            ownDrownTime -= Time.deltaTime;
            yield return null;
            if (ownDrownTime <= 0)
            {
                ChangeState(State.Die);
                Iscoroutine = false;
                break;
            }
        }
    }
    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
        playerMediator.playerStats.aliveSpeed = playerMediator.playerStats.OwnSpeed;
        ChangeState(State.Alive);
    }
    public void ChangeState(State playerState)
    {
        ownState = playerState;
        switch (playerState)
        {
            case State.Alive:
                Alive();
                break;
            case State.Trapped:
                Trapped();
                break;
            case State.Die:
                Die();
                break;
            case State.Devil:
                Devil();
                break;
        }
    }
    void Alive()
    {
        bubbleCollider.gameObject.SetActive(false);
        transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (transform.parent.gameObject.layer != 3) { transform.parent.gameObject.layer = 3; }

        playerMediator.playerStats.OwnSpeed = playerMediator.playerStats.aliveSpeed;

        if (coroutinedrown != null)
        {
            StopCoroutine(coroutinedrown); // 부활시 익사 코루틴을 멈춰줘야함 -> 유찬규
        }

        if (maxDrownTime != ownDrownTime)
        {
            ownDrownTime = maxDrownTime;
        }

    }
    void Trapped()
    {
        transform.parent.gameObject.layer = 0;

        transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        bubbleCollider.gameObject.SetActive(true);

        playerMediator.playerStats.aliveSpeed = playerMediator.playerStats.OwnSpeed;
        playerMediator.playerStats.OwnSpeed = playerMediator.playerStats.trapSpeed;
        coroutinedrown = StartCoroutine(DrownCoroutine());
    }
    void Die()
    {

        playerMediator.playerStats.OwnSpeed = playerMediator.playerStats.dieSpeed;
        StartCoroutine(DieTime());      // Die애니메이션 재생을 위한 시간벌이 코루틴 -> 유찬규 추가
        OnDied?.Invoke(this); //죽었을 때 RoundManager에게 사망 이벤트 통보용.
    }

    /// <summary>
    /// 제작 : 찬규 
    /// 죽자마자 바로 게임오브젝트의 active를 false로 해버리면 die 애니메이션이 재생이 될 시간이 없음
    /// 고로 0.5초를 확보해서 죽는 애니메이션을 재생할 시간을 마련해야함
    /// </summary>
    /// <returns></returns>
    IEnumerator DieTime()
    {
        yield return new WaitForSeconds(3f);
        GetComponentInParent<PlayerMediator>().gameObject.SetActive(false);
    }

    IEnumerator Devil_1()
    {
        while (true)
        {
            playerMediator.playerInputHandler.InputPlant(playerMediator.playerTileCalculator.nowTile.tileNode.posX, playerMediator.playerTileCalculator.nowTile.tileNode.posY);
            ownDevilTime -= Time.deltaTime;
            yield return null;
            if (ownDevilTime <= 0)
            {
                ChangeState(State.Alive);
                break;
            }
        }
    }
    IEnumerator Devil_2()
    {

        while (true)
        {
            //playerMediator.playerInputHandler.moveDir = -playerMediator.playerInputHandler.moveDir;
            ownDevilTime -= Time.deltaTime;
            yield return null;
            if (ownDevilTime <= 0)
            {
                ChangeState(State.Alive);
                break;
            }
        }
    }
    void Devil()
    {
        if (ownDevilTime != maxDevilTime) { ownDevilTime = maxDevilTime; }
        int a = Random.Range(0, 2);
        if (a != 0)
        {
            Debug.Log("1번 데빌");
            coroutinedevil = StartCoroutine(Devil_1());
        }
        else
        {
            Debug.Log("2번 데빌");
            coroutinedevil = StartCoroutine(Devil_2());
        }
    }
}