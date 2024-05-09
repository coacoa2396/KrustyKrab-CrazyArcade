using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 패시브아이템의 베이스 세팅
/// </summary>
public class PassiveBase : Item
{
    [SerializeField] PlayerMediator player;            // 스탯을 올려줄 플레이어
    public PlayerMediator Player {get {return player;} set { player = value; } }
}
