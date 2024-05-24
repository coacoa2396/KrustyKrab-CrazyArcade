using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 게임씬에서 사이드UI
/// </summary>
public class SideUI : MonoBehaviour
{
    [SerializeField] SidePlayerInfo prefab;

    public void InitSideUI()
    {
        if (RoundManager.Round == null)
        {
            Debug.LogError("Round is null");
        }

        if (RoundManager.Round.PlayerList == null)
        {
            Debug.LogError("PlayerList is null");
        }

        if (RoundManager.Round.PlayerList[0] == null)
        {
            Debug.LogError("PlayerList[0] is null");
        }

        int playerNum = RoundManager.Round.PlayerList.Count;

        if (playerNum == 0)
            Debug.LogError("0");

        Debug.Log($"playerMum is {playerNum}");

        for (int i = 0; i < playerNum; i++)
        {
            Instantiate(prefab, transform);
        }
    }
}
