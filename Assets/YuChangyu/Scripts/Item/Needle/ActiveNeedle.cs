using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStateMachine;
/// <summary>
/// 제작 : 찬규 
/// 액티브아이템 : Needle의 사용 시 기능
/// </summary>
public class ActiveNeedle : ActiveBase
{
    int useNumber;          // 사용횟수

    public override void Use()
    {
        SaveMyself();
    }

    public void SaveMyself()
    {
        if (!(Player.playerState.ownState == State.Trapped))         // 물방울에 갖힌 상태가 아니면
            return;                                                         // 리턴

        // 방울에서 나오는 애니메이션 재생
        Player.playerAnimCon.Animator.SetTrigger("Revive");

        Player.playerState.ChangeState(State.Alive);       // 플레이어의 상태를 Alive로 바꿔준다
        useNumber--;

        // 사용횟수를 다 쓰면 CurActiveItem에서 제거하기
        if (useNumber == 0)
            Player.CurActiveItem = null;
    }

    public override void Init(PlayerMediator player)
    {
        base.Init(player);
        useNumber = 1;
    }
}
