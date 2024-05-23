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
        int playerNum = RoundManager.Round.PlayerList.Count;

        for (int i = 0; i < playerNum; i++)
        {
            Instantiate(playerInfoPrefab, transform);
        }
    }
}
