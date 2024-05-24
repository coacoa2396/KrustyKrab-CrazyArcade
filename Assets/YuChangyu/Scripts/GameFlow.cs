using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static RoundManager;
/// <summary>
/// 제작 : 찬규
/// 게임씬의 게임플로우를 담당
/// </summary>
public class GameFlow : MonoBehaviourPun
{
    [SerializeField] TimeChecker timeChecker;       // 게임타임을 체크하는 타임체커
    [SerializeField] Image resultUI;                // 게임 결과창

    public void Judge()         // 게임종료 판정 -> 플레이어들의 OnDied 이벤트 함수에 넣어주자
    {
        if (Round.SurvivorList.Count == 1)
        {
            StopGame();

            foreach (PlayerRoundData _p in Round.PlayerList)
            {
                if (_p.player != Round.SurvivorList[0])             // 남은 생존자 본인이 아니면
                {
                    _p.outcome = Outcome.lose;
                }
                // 생존자를 찾았으면
                else
                {
                    _p.outcome = Outcome.Win;
                }
            }

            OnResult();
        }
        else
        {
            TimeOut();
        }
    }

    // 멈추는 기능
    public void StopGame()
    {
        // 어떻게 멈출까?
        // 1. 타임스케일을 0으로 하고 UI는 unscaledTime으로 해준다 -> 움직임이 멈추면 이상하니까 기각
        // 2. 플레이어들의 인풋시스템을 꺼버린다 -> 이게 편할지도?
        foreach (PlayerRoundData _p in Round.PlayerList)
        {
            _p.player.GetComponent<PlayerInput>().enabled = false;
        }
    }

    // 결과창을 띄우는 기능
    public void OnResult()
    {
        resultUI.gameObject.SetActive(true);
        StartCoroutine(GoRoom());
    }

    // 결과창을 띄운 후 몇초 뒤에 룸으로 보내는 기능 (코루틴)
    IEnumerator GoRoom()
    {
        yield return new WaitForSeconds(6f);
        Manager.Scene.GetCurScene<GameScene>().GoToRoom();
    }

    // 게임시간의 종료를 체크한다
    public void TimeOut()
    {
        // 타임체커의 시간이 다 안되었을 경우
        if (timeChecker.GameTime >= 0)
            return;

        StopGame();

        // 생존 플레이어들의 outcome을 draw로
        foreach (PlayerRoundData _p in Round.PlayerList)
        {
            if (_p.player?.GetComponentInChildren<PlayerStateMachine>().ownState == PlayerStateMachine.State.Alive)
            {
                _p.outcome = Outcome.draw;
            }
        }

        OnResult();
    }
}
