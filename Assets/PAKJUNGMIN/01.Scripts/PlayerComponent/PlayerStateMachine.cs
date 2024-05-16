using pakjungmin;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerMediator playerMediator;

    public enum State
    {
        Alive,
        Trapped,
        Die,
    }
    [Header("물방울 갇혔을 때, 익사 시간")]
    [SerializeField] float drownTimer;
    public float DrownTimer {get { return drownTimer;}} // 익사시간 프로퍼티 추가, 애니메이션에서 사용하기 위함 -> 유찬규 추가
    [SerializeField] float ownTimer;

    Coroutine coroutinedrown;
    [Header("플레이어의 상태")]
    public State ownState;

    IEnumerator DrownCoroutine()
    {
        while (true)
        {
            ownTimer -= 1f;
            yield return new WaitForSeconds(1f);
            if(ownTimer <= 0)
            {
                ChangeState(State.Die);
                break;
            }
        }
    }

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
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
        }
    }
    void Alive()
    { 
        if(drownTimer != ownTimer) { ownTimer = drownTimer; }

    }
    void Trapped() 
    {

        Debug.Log("플레이어의 상태: 갇힘");

        playerMediator.playerStats.OwnSpeed = 0.2f;
        coroutinedrown = StartCoroutine(DrownCoroutine());       
    }
    void Die()
    {

        Debug.Log("플레이어 사망");
        StartCoroutine(DieTime());      // Die애니메이션 재생을 위한 시간벌이 코루틴 -> 유찬규 추가
    }
    /// <summary>
    /// 제작 : 찬규 
    /// 죽자마자 바로 게임오브젝트의 active를 false로 해버리면 die 애니메이션이 재생이 될 시간이 없음
    /// 고로 0.5초를 확보해서 죽는 애니메이션을 재생할 시간을 마련해야함
    /// </summary>
    /// <returns></returns>
    IEnumerator DieTime()
    {
        yield return new WaitForSeconds(1f);
        GetComponentInParent<PlayerMediator>().gameObject.SetActive(false);
    }
}
