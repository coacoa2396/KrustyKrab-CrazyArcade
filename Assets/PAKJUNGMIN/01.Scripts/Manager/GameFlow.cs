using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static RoundManager;
/// <summary>
/// 제작 : 찬규
/// 게임씬의 게임플로우를 담당
/// </summary>
public class GameFlow : MonoBehaviour
{
    [SerializeField] TimeChecker timeChecker;       // 게임타임을 체크하는 타임체커
    [SerializeField] Image resultUI;                // 게임 결과창

    public void Judge()         // 게임종료 판정
    {
        if (Round.SurvivorList.Count == 1)
        {
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
        }
        else
        {
            TimeOut();
        }
    }

    public void TimeOut()
    {
        // 타임체커의 시간이 다 되었을 경우
        if (timeChecker.GameTime <= 0)
        {
            // 생존 플레이어들의 outcome을 draw로
            foreach (PlayerRoundData _p in Round.PlayerList)
            {
                if (_p.player?.GetComponentInChildren<PlayerStateMachine>().ownState == PlayerStateMachine.State.Alive)
                {
                    _p.outcome = Outcome.draw;
                }
            }
            return;
        }
    }
}
