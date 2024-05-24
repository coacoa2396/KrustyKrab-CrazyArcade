using Photon.Pun;
using Photon.Realtime;
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
    public PlayerEntity playerEntity;

    public PlayerRoundData(GameObject player_)
    {
        this.player = player_;
        int ownerId = player.GetComponent<PhotonView>().OwnerActorNr;
        foreach (Player _player in PhotonNetwork.PlayerList)
        {
            if (_player.ActorNumber == ownerId)
            {
                foreach (PlayerEntity playerEntity in Manager.Game.GamePlayers)
                {
                    if (_player.NickName.Equals(playerEntity.Key))
                    {
                        this.playerEntity = playerEntity;
                    }
                }
            }
        }
        Debug.Log(playerEntity);
    }
}
