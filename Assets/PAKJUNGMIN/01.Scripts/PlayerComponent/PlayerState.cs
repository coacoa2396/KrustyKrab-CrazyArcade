using pakjungmin;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerMediator playerMediator;


    //임시로 쓸 필드와 스프라이트 --> PlayerAnimator에서 재구현.
    [SerializeField] Sprite trapped;
    [SerializeField] Sprite died;


    public enum State
    {
        Alive,
        Trapped,
        Die,
    }
    [SerializeField] float drownTimer;
    [SerializeField] float ownTimer;

    Coroutine coroutinedrown;
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

        playerMediator.GetComponentInParent<SpriteRenderer>().sprite = trapped; //--> PlayerAnimator에서 재구현.

        playerMediator.playerStats.Speed = 0.2f;
        coroutinedrown = StartCoroutine(DrownCoroutine());       
    }
    void Die()
    {

        playerMediator.GetComponentInParent<SpriteRenderer>().sprite = died; //--> PlayerAnimator에서 재구현.

        Debug.Log("플레이어 사망");
        GetComponentInParent<PlayerMediator>().gameObject.SetActive(false);
    }
    
}
