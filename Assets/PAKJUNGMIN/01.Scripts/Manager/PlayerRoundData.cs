using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Struct : 플레이어의 승패 여부 필드를 가진 구조체
/// </summary>
public class PlayerRoundData
{
    public GameObject player;
    public RoundManager.Outcome outcome;

    public PlayerRoundData(GameObject player_)
    {
        this.player = player_;
        Debug.Log($"{this.player.name} 플레이어 정보 객체 생성");
    }
}
