using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 결과창의 플레이어리스트 
/// </summary>
public class PlayerList : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfoPrefab;

    private void Start()
    {
        List<PlayerRoundData> list = RoundManager.Round.PlayerList;

        foreach (PlayerRoundData p in list)
        {
            UserDataManager.SetPlayerExp(p.playerEntity, 10);
            PlayerInfo _playerInfo = Instantiate(playerInfoPrefab, transform);
            _playerInfo.SetPlayerInfo(p);
        }
    }
}
