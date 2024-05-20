using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 액티브아이템 : Shield의 사용 시 기능
/// </summary>
public class ActiveShield : ActiveBase
{
    [SerializeField] float godTime;

    bool casting;       // 사용중 체크
    bool godMode;       // 무적 체크

    public override void Use()
    {
        if (casting)                // 중복사용 방지
            return;
        casting = true;
        Protected();
    }

    void Protected()
    {
        StartCoroutine(GodMode());      // 무적 코루틴

        UseNumber--;

        if (UseNumber == 0)
            Player.CurActiveItem = null;
    }

    IEnumerator GodMode()
    {
        godMode = true;
        yield return new WaitForSeconds(godTime);
        godMode = false;
        casting = false;
    }

    public override void Init(PlayerMediator player)
    {
        base.Init(player);
        Name = "Shield";
        UseNumber = 2;
    }
}
