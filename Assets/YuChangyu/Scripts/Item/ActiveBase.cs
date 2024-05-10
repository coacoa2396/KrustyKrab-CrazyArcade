using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 액티브아이템의 베이스
/// </summary>
public class ActiveBase : Item
{
    [SerializeField] PlayerMediator player;            // 플레이어
    public PlayerMediator Player { get { return player; } set { player = value; } }

    
}
