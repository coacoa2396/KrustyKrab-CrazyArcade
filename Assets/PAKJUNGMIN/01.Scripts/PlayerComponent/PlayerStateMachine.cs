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
    float ownTimer;

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
        GetComponentInParent<PlayerMediator>().gameObject.SetActive(false);
    }
    
}
